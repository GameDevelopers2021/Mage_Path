using System;
using InputSystem;
using UnitsClasses;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Units.UnitsClasses
{
    public class EnemyBfsMoving : UnitMoving
    {
        [SerializeField] private Tilemap wallTilemap;
        private GameObject player;
        private TilemapPathFinder pathFinder;
        private Vector2 nextPosition;
        private Vector2 requiredVelocity = Vector2.positiveInfinity;
        private PlayerControll controller;

        private void Awake()
        {
            base.Awake();
            controller = new PlayerControll();
            pathFinder = new TilemapPathFinder(wallTilemap);
        }
        
        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            // controller.Player.MouseMoving.performed += context =>
            // {
            //     var t = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            //     Debug.Log($"{t} {wallTilemap.WorldToCell(t)}");
            //     Debug.Log(pathFinder.tilemap.GetTile(wallTilemap.WorldToCell(t)));
            // };
        }

        private void OnEnable()
        {
            controller.Enable();
        }

        private new void OnDisable()
        {
            base.OnDisable();
            controller.Disable();
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();
        }

        private void Move()
        {
            if (requiredVelocity != Vector2.positiveInfinity 
                && (Rigidbody.velocity - requiredVelocity).magnitude < 1e-2)
            {
                if (!(((Vector2)transform.position - nextPosition).magnitude < 1e-2))
                {
                    return;
                }
            }
            
            var path = pathFinder.FindPathOnTilemap(transform.position, player.transform.position);
            if (path.Count == 0)
                return;
            nextPosition = path[0];
            MoveToPoint(nextPosition);
        }

        private void MoveToPoint(Vector2 point)
        {
            requiredVelocity = point - (Vector2) transform.position;
            Move(requiredVelocity);
        }
    }
}