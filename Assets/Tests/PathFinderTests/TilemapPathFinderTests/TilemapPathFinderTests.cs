using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Units.UnitsClasses;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace Tests.PathFinderTests
{
    [TestFixture]
    public class TilemapPathFinderTests
    {
        private static readonly Dictionary<string, TestData> MapsData = new Dictionary<string, TestData>
        {
            {
                "NoWall1", 
                new TestData(@"
******
*S..F*
******", 0, 0, 4)
            },
            {
                "NoWall2",
                new TestData(@"
**********
*..S.....*
*........*
*......F.*
**********", 0, 0, 7)
            },
            {
                "NoWall3",
                new TestData(@"
**********
*.F......*
*........*
*......S.*
**********", -95, -10, 8)
            },
            {
                "Wall1",
                new TestData(@"
**********
*.F......*
*........*
********.*
*.S......*
**********", 0, 0, 16)
            },
            {
                "Wall2",
                new TestData(@"
**********
*......F.*
*.********
*...**.S.*
*........*
**********", 0, 0, 20)
            },
            {
                "Wall3",
                new TestData(@"
******
*.F..*
*.*..*
*.S..*
******", 0, 0, 20)
            },
            {
                "NoPath",
                new TestData(@"
**********
*......F.*
**********
*......S.*
*........*
**********", 0, 0, 2)
            },
        };

        [TestCase("NoWall1")]
        [TestCase("NoWall2")]
        [TestCase("NoWall3")]
        public void NoWall(string mapsDataKey)
        {
            RunTest(MapsData[mapsDataKey]);
        }

        [TestCase("Wall1")]
        [TestCase("Wall2")]
        [TestCase("Wall3")]
        public void Wall(string mapsDataKey)
        {
            RunTest(MapsData[mapsDataKey]);
        }
        
        [TestCase("NoPath")]
        public void NoPath(string mapsDataKey)
        {
            var hasException = false;
            
            try
            {
                RunTest(MapsData[mapsDataKey]);
            }
            catch (ArgumentException)
            {
                hasException = true;
            }
            
            Assert.True(hasException);
        }
        
        private void RunTest(TestData data)
        {
            var (tilemap, startCell, finishCell) = TestParser.ConvertToTestSet(data.Map, data.CellMinY, data.CellMinX);
            var startPosition = (Vector2)tilemap.GetCellCenterWorld((Vector3Int) startCell);
            var finishPosition = (Vector2)tilemap.GetCellCenterWorld((Vector3Int) finishCell);
            var expectedPathLength = data.MaxPathLength;
            
            var finder = new TilemapPathFinder(tilemap, finishPosition);
            var currentPosition = startPosition;
            
            for (var i = 0; i < expectedPathLength - 1; i++)
            {
                currentPosition = finder.GetNextPointOfPath(currentPosition);
            }
            
            Assert.AreEqual(
                0, 
                (finishPosition - currentPosition).magnitude, 1e-4, 
                $"Path doesn't arrive to finish in {expectedPathLength} steps");
        }
    }

    internal static class TestParser
    {
        /// <summary>
        /// tilemap sort order - bottom left
        /// start and finish - cells, not coordinates 
        /// </summary>
        public static (Tilemap tilemap, Vector2Int start, Vector2Int finish) ConvertToTestSet(string map, int yMin, int xMin)
        {
            var wallTileBase = ScriptableObject.CreateInstance<Tile>();
            
            var map2d = map.Split(new []{"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var mapLinesSize = new Vector2Int(map2d[0].Length, map2d.Length);
            
            var grid = new GameObject();
            grid.AddComponent<Grid>();
            grid.transform.position = new Vector3(0, 0, 0);
            grid.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            
            var tilemapObject = new GameObject();
            tilemapObject.transform.SetParent(grid.transform);
            
            var tilemap = tilemapObject.AddComponent<Tilemap>();
            tilemap.tileAnchor = new Vector3(0.5f, 0.5f, 0);
            var (start, finish) = (Vector2Int.zero, Vector2Int.zero);

            var yMax = yMin + mapLinesSize.y;
            var xMax = xMin + mapLinesSize.x;

            for (var i = yMin; i < yMax; i++)
            for (var j = xMin; j < xMax; j++)
            {
                var position = new Vector3Int(j, i, 0);
                var tileChar = map2d[mapLinesSize.y - 1 - (i - yMin)][j - xMin];
                var tile = (TileBase) null;

                switch (tileChar)
                {
                    case '*':
                        tile = wallTileBase;
                        break;
                    case 'S':
                        start = new Vector2Int(j, i);
                        break;
                    case 'F':
                        finish = new Vector2Int(j, i);
                        break;
                }
                
                if (tile != null)
                    tilemap.SetTile(position, tile);
            }

            return (tilemap, start, finish);
        }
    }

    internal class TestData
    {
        public readonly string Map;
        public readonly int CellMinX;
        public readonly int CellMinY;
        public readonly int MaxPathLength;

        public TestData(string map, int cellMinX, int cellMinY, int maxPathLength)
        {
            Map = map;
            CellMinX = cellMinX;
            CellMinY = cellMinY;
            MaxPathLength = maxPathLength;
        }
    }
}
