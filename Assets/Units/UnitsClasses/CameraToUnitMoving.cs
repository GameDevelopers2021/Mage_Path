using Unity.Mathematics;
using UnityEngine;

namespace UnitsClasses
{
    public class CameraToUnitMoving : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private float smoothingFactor = 0.05f;
        private float cameraSize;

        void Start()
        {
            cameraSize = gameObject.GetComponent<Camera>().orthographicSize;
        }
        
        private void FixedUpdate()
        {
            var position = transform.position;
            var playerPosition = player.transform.position;
            
            transform.position = new Vector3(
                math.lerp(position.x, playerPosition.x, smoothingFactor),
                position.y,
                position.z);

            var cameraBottom = position.y - cameraSize;
            var cameraTop = position.y + cameraSize;
            if (playerPosition.y < cameraBottom)
            {
                HandlePlayerExitingOutOfSightByY(Vector2.down);
            }
            else if (playerPosition.y > cameraTop)
            {
                HandlePlayerExitingOutOfSightByY(Vector2.up);
            }
        }

        private void HandlePlayerExitingOutOfSightByY(Vector2 directionFromNearestCameraBorderToPlayer)
        {
            transform.position += (Vector3)directionFromNearestCameraBorderToPlayer.normalized * (cameraSize * 2);
        }
    }
}
