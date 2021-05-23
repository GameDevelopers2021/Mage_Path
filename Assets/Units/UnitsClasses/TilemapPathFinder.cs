using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Units.UnitsClasses
{
    public class TilemapPathFinder
    {
        private readonly List<Vector2Int> offsets;
        private readonly Tilemap tilemap;
        private readonly Dictionary<Vector2Int, TileBase> tiles2d;
        private readonly Func<Vector2Int, bool> IsReachableCell;
        private readonly float maxSearchingDistance;
        private BoundsInt bounds;
        private Dictionary<Vector2Int, CellInfo> cellsData;
        private Vector2 startInWorld;
        private HashSet<Vector2Int> used;
        private int maxDepth = 30;

        public Vector2 StartInWorld 
        { 
            get => startInWorld;
            set
            {
                startInWorld = value;
                cellsData = CalculateDataAboutCells((Vector2Int)tilemap.WorldToCell(startInWorld));
            }
        }
        
        /// <param name="tilemap">sort order - bottom left</param>
        public TilemapPathFinder(
            Tilemap tilemap, 
            Vector2 startInWorld,
            float maxSearchingDistance = float.MaxValue,
            Func<Vector2Int, bool> ConditionOfReachableCell = null)
        {
            this.tilemap = tilemap;
            this.maxSearchingDistance = maxSearchingDistance;
            IsReachableCell = ConditionOfReachableCell ?? IsEmptyTile;
            offsets = new List<Vector2Int>
            {
                Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
            };
            bounds = tilemap.cellBounds;
            var tiles = tilemap.GetTilesBlock(bounds);
            tiles2d = new Dictionary<Vector2Int, TileBase>();
            var k = 0;
            for (var i = bounds.yMin; i < bounds.yMax; i++)
            for (var j = bounds.xMin; j < bounds.xMax; j++)
            {
                tiles2d[new Vector2Int(j, i)] = tiles[k];
                k++;
            }
            StartInWorld = startInWorld;
        }

        public List<Vector2> FindPathOnTilemap(Vector2 finishInWorld)
        {
            var startCell = (Vector2Int)tilemap.WorldToCell(startInWorld);
            var finishCell = (Vector2Int)tilemap.WorldToCell(finishInWorld);
            
            return GetPathFromSearchingInfo(cellsData, startCell, finishCell);
        }

        public Vector2 GetNextPointOfPath(Vector2 currentPositionInWorld)
        {
            var currentCell = (Vector2Int)tilemap.WorldToCell(currentPositionInWorld);

            if (cellsData.TryGetValue(currentCell, out var currentCellInfo))
            {
                return tilemap.GetCellCenterWorld((Vector3Int)currentCellInfo.PreviousCellPosition);
            }

            throw new ArgumentException("No path from current position");
        }

        private Dictionary<Vector2Int, CellInfo> CalculateDataAboutCells(Vector2Int start)
        {
            used = new HashSet<Vector2Int>();
            var queue = new Queue<Vector2Int>();
            var newQueue = new Queue<Vector2Int>();
            var result = new Dictionary<Vector2Int, CellInfo>();

            queue.Enqueue(start);
            result[start] = new CellInfo(start, 0);
            var depth = 0;
            while (queue.Count != 0 && depth <= maxDepth)
            {
                newQueue = new Queue<Vector2Int>();
                while (queue.Count != 0)
                {
                    var cell = queue.Dequeue();
                    var cellInfo = result[cell];
                    foreach (var offset in offsets)
                    {
                        var adjacentCell = cell + offset;
                        if (!IsReachableCell(adjacentCell) || used.Contains(adjacentCell))
                            continue;
                        result[adjacentCell] = new CellInfo(cell, cellInfo.Distance + 1);
                        
                        newQueue.Enqueue(adjacentCell);
                        used.Add(adjacentCell);
                    }
                }

                depth++;
                queue = newQueue;
            }

            return result;
        }

        private List<Vector2> GetPathFromSearchingInfo(
            Dictionary<Vector2Int, CellInfo> mapData, 
            Vector2Int start, 
            Vector2Int finish)
        {
            var result = new List<Vector2>();
            
            var currentCell = finish;
            while (currentCell != start)
            {
                result.Add(tilemap.GetCellCenterWorld((Vector3Int)currentCell));
                currentCell = mapData[currentCell].PreviousCellPosition;
            }
            result.Add(tilemap.GetCellCenterWorld((Vector3Int)currentCell));

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

            var searching = tiles2d.TryGetValue(tilePosition, out var tile);

            if (searching)
            {
                return tile == null;
            }

            return false;
        }
    }

    internal class CellInfo
    {
        public Vector2Int PreviousCellPosition { get; set; }
        public int Distance { get; set; }
        
        public CellInfo(Vector2Int previous, int distance = int.MaxValue)
        {
            PreviousCellPosition = previous;
            Distance = distance;
        }
    }
}