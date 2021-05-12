using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Units.UnitsClasses
{
    public class TilemapPathFinder
    {
        private readonly Dictionary<Directions2D, Vector2Int> directionsMatches;
        private readonly Dictionary<Vector2Int, Directions2D> vectorsMatches;
        public Tilemap tilemap;
        private TileBase[] tiles;
        private Dictionary<Vector2Int, int> tiles2d;
        private BoundsInt bounds;
        private Func<Vector2Int, bool> IsReachableCell;

        public TilemapPathFinder(Tilemap tilemap, Func<Vector2Int, bool> ConditionOfReachableCell = null)
        {
            this.tilemap = tilemap;
            IsReachableCell = ConditionOfReachableCell ?? IsEmptyTile;
            directionsMatches = new Dictionary<Directions2D, Vector2Int>
            {
                {Directions2D.Up, Vector2Int.up},
                {Directions2D.Down, Vector2Int.down},
                {Directions2D.Left, Vector2Int.left},
                {Directions2D.Right, Vector2Int.right}
            };
            vectorsMatches = new Dictionary<Vector2Int, Directions2D>
            {
                {Vector2Int.up, Directions2D.Up},
                {Vector2Int.down, Directions2D.Down},
                {Vector2Int.left, Directions2D.Left},
                {Vector2Int.right, Directions2D.Right}
            };
            bounds = tilemap.cellBounds;
            tiles = tilemap.GetTilesBlock(bounds);
            tiles2d = new Dictionary<Vector2Int, int>();
            var k = 0;
            for (var i = bounds.yMin; i <= bounds.yMax; i++)
            for (var j = bounds.xMin; j <= bounds.xMax; j++)
            {
                tiles2d[new Vector2Int(j, i)] = k;
                k++;
            }
        }

        public List<Vector2> FindPathOnTilemap(Vector2 startInWorld, Vector2 finishInWorld)
        {
            var startCell = new Vector2Int((int) math.round(startInWorld.x), (int) math.round(startInWorld.y));
            var finishCell = new Vector2Int((int) math.round(finishInWorld.x), (int) math.round(finishInWorld.y));
            return FindDirectionsPathOnTilemap(startCell, finishCell);
            //return new List<Vector2>();
        }

        private List<Vector2> FindDirectionsPathOnTilemap(Vector2Int start, Vector2Int finish)
        {
            var used = new HashSet<Vector2Int>();
            var queue = new Queue<Vector2Int>();
            var searchingData = new Dictionary<Vector2Int, SearchingInfo>();

            queue.Enqueue(start);
            searchingData[start] = new SearchingInfo(start, 0);
            while (queue.Count != 0)
            {
                var cell = queue.Dequeue();
                var cellInfo = searchingData[cell];
                foreach (var offset in directionsMatches.Select(keyValue => keyValue.Value))
                {
                    var adjacentCell = cell + offset;
                    if (!IsReachableCell(adjacentCell))
                        continue;
                    if (!searchingData.TryGetValue(adjacentCell, out var adjacentCellInfo))
                    {
                        searchingData[adjacentCell] = new SearchingInfo(cell, cellInfo.Distance + 1);
                    }
                    else
                    {
                        var potentialMinDistance = cellInfo.Distance + 1;
                        if (adjacentCellInfo.Distance > potentialMinDistance)
                        {
                            adjacentCellInfo.Distance = potentialMinDistance;
                            adjacentCellInfo.PreviousCellPosition = cell;
                        }
                    }

                    if (cell == finish)
                        break;
                    if (used.Contains(adjacentCell))
                        continue;
                    queue.Enqueue(adjacentCell);
                    used.Add(adjacentCell);
                }
            }

            return GetPathFromSearchingInfo(searchingData, start, finish);
        }

        private List<Vector2> GetPathFromSearchingInfo(
            Dictionary<Vector2Int, SearchingInfo> searchingData, 
            Vector2Int start, 
            Vector2Int finish)
        {
            var result = new List<Vector2>();
            
            var currentCell = finish;
            while (currentCell != start)
            {
                result.Add(tilemap.GetCellCenterWorld((Vector3Int)currentCell));
                currentCell = searchingData[currentCell].PreviousCellPosition;
            }

            result.Reverse();
            return result;
        }

        private bool IsEmptyTile(Vector2Int tilePosition)
        {
            if (tilePosition.x < bounds.xMin
                || tilePosition.x > bounds.xMax
                || tilePosition.y < bounds.yMin
                || tilePosition.y > bounds.yMax)
            {
                return false;
            }
            // if (t < 0 || t > tiles.Length)
            // {
            //     Debug.Log(tilePosition);
            //     t = ConvertToTileIndex(tilePosition);
            //     Debug.Log(t);
            // }
            var t = tilemap.GetTile((Vector3Int) tilePosition);
            return !(t != null);
        }

        private int ConvertToTileIndex(Vector2Int tilePosition)
        {
            // var anchorZero = new Vector2Int(bounds.xMax - bounds.size.x - 1, bounds.yMin + bounds.size.y);
            // var vectorToTilePosition = tilePosition - anchorZero;
            // vectorToTilePosition.y = -vectorToTilePosition.y;
            //
            // return vectorToTilePosition.x + vectorToTilePosition.y * bounds.size.x;
            return tiles2d[tilePosition];
        }
    }

    internal class SearchingInfo
    {
        public Vector2Int PreviousCellPosition { get; set; }
        public int Distance { get; set; }
        
        public SearchingInfo(Vector2Int previous, int distance = int.MaxValue)
        {
            PreviousCellPosition = previous;
            Distance = distance;
        }
    }

    internal enum Directions2D
    {
        Up,
        Down,
        Right,
        Left
    }
}