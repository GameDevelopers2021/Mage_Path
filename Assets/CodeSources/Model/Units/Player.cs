using UnityEngine;

namespace CodeSources.Model.Units
{
    public class Player : UnitBase
    {
        public Player(GameObject enemy, int health = 100, int mana = 100, float speed = 10)
            : base(enemy, health, mana, speed)
        {
            enemy.tag = "Player";
        }
        
        public void RotateByMousePosition(Vector2 screenMousePosition, Camera cameraDetectedMouse)
        {
            var worldMousePosition = (Vector2)cameraDetectedMouse.ScreenToWorldPoint(screenMousePosition);
            var playerPosition = Transform.position;
            var playerViewVector = (Vector2)UnitObject.transform.right;
            var expectedPlayerView = worldMousePosition - new Vector2(playerPosition.x, playerPosition.y);
            var rotationAngle = Vector2.SignedAngle(playerViewVector, expectedPlayerView);
            Transform.Rotate(Vector3.forward, rotationAngle, Space.World);
        }
    }
}