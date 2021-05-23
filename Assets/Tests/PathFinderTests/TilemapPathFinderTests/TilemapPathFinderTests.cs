using System;
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
        [TestCase(
            @"
******
*S..F*
******",
            0,
            0,
            TestName = "NoWall1")]
        public void NoWallTest(string map, int yMin, int xMin)
        {
            var (tilemap, start, finish) = TestMaps.ConvertToTestSet(map, yMin, xMin);
            var finder = new TilemapPathFinder(tilemap, start);
            var list = finder.FindPathOnTilemap(finish);
        }
    }

    internal static class TestMaps
    {
        private static readonly TileBase WallTileBase = ScriptableObject.CreateInstance<Tile>();

        /// <summary>
        /// tilemap sort order - bottom left
        /// </summary>
        public static (Tilemap tilemap, Vector2 start, Vector2 finish) ConvertToTestSet(string map, int yMin, int xMin)
        {
            var map2d = map.Split(new []{"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var mapLinesSize = new Vector2Int(map2d[0].Length, map2d.Length);
            var obj = new GameObject();
            var tilemap = obj.AddComponent<Tilemap>();
            var (start, finish) = (Vector2.zero, Vector2.zero);

            var yMax = yMin + mapLinesSize.y;
            var xMax = xMin + mapLinesSize.x;

            for (var i = yMin; i < yMax; i++)
            for (var j = xMin; j < xMax; j++)
            {
                var position = new Vector3Int(j, i, 0);
                var tileChar = map2d[i - yMin][j - xMin];
                var tile = (TileBase) null;

                if (tileChar == '*')
                {
                    tile = WallTileBase;
                }
                else if (tileChar == 'S')
                {
                    start = new Vector2(j, i);
                }
                else if (tileChar == 'F')
                {
                    finish = new Vector2(j, i);
                }
                
                if (tile != null)
                    tilemap.SetTile(position, tile);
            }

            return (tilemap, start, finish);
        }
    }
}
