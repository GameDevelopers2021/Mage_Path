using UnitsClasses;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Units.UnitsClasses
{
    public class EnemyBfsMoving : UnitMoving
    {
        [SerializeField] private Tilemap wallTilemap;
        private GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();
        }

        private void Move()
        {
            var bounds = wallTilemap.cellBounds;
            var tiles = wallTilemap.GetTilesBlock(bounds);
            
        }
    }
}