using UnityEngine;
using UnityEngine.Tilemaps;

namespace Units.UnitsClasses
{
    public class PathFindingSystem : MonoBehaviour
    {
        [SerializeField] private GameObject startObject;
        [SerializeField] private Tilemap wallTilemap;
        private Vector3 startObjectLastPosition;
        private TilemapPathFinder pathFinder;

        public GameObject StartObject => startObject;
        
        public PathFindingSystem() 
        {}
        
        public PathFindingSystem(GameObject startObject)
        {
            this.startObject = startObject;
        }

        public Vector2 GetNextPosition(Vector2 currentPosition)
        {
            var startObjectPosition = startObject.transform.position;
            var distanceFromLastPosition = (startObjectPosition - startObjectLastPosition).magnitude;
            if (!(distanceFromLastPosition < 0.1))
            {
                startObjectLastPosition = startObjectPosition;
                pathFinder.StartInWorld = startObjectPosition;
            }
            
            return pathFinder.GetNextPointOfPath(currentPosition);
        }

        private void Awake()
        {
            startObjectLastPosition = startObject.transform.position;
            pathFinder = new TilemapPathFinder(wallTilemap, startObjectLastPosition);
        }
    }
}
