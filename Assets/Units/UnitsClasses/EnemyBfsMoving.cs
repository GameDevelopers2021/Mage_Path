using System;
using System.Linq;
using InputSystem;
using UnitsClasses;
using UnityEngine;
using UnityEngine.EventSystems;
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
        private bool isBfs = false;

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
            transform.rotation = new Quaternion(0, 0, 0, 0);
            var hits = Physics2D.RaycastAll(
                transform.position, 
                player.transform.position - transform.position,
                (player.transform.position - transform.position).magnitude);
            if (!hits.Any(hit => hit.collider.CompareTag("Immortal")) 
                && isBfs && ((Vector2)transform.position - nextPosition).magnitude < 0.1
                || !isBfs && !hits.Any(hit => hit.collider.CompareTag("Immortal")))
            {
                requiredVelocity = Vector2.positiveInfinity;
                Move(player.transform.position - transform.position);
                isBfs = false;
                return;
            }
            
            //Rigidbody.velocity = Vector2.zero;
            isBfs = true;
            Move();
        }

        private void Move()
        {
            Debug.Log($"{transform.position} {nextPosition} {((Vector2)transform.position - nextPosition).magnitude}");
            if (requiredVelocity != Vector2.positiveInfinity 
                && !(Rigidbody.velocity.magnitude < 1e-2))
            {
                if (!(((Vector2)transform.position - nextPosition).magnitude < 0.1))
                {
                    return;
                }

                var k = 0;
            }
            
            var path = pathFinder.FindPathOnTilemap(transform.position, player.transform.position);
            if (path.Count == 0)
                return;
            nextPosition = path[0];
            MoveToPoint(nextPosition);
        }

        private void MoveToPoint(Vector2 point)
        {
            Move(point - (Vector2) transform.position);
            requiredVelocity = (point - (Vector2) transform.position).normalized * Speed;
        }
    }
}