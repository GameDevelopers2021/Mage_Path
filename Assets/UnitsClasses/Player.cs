﻿using UnityEngine;

namespace UnitsClasses
{
    public class Player : UnitComponent
    {
        public void RotateByMousePosition(Vector2 screenMousePosition, Camera cameraDetectedMouse)
        {
            // var worldMousePosition = (Vector2)cameraDetectedMouse.ScreenToWorldPoint(screenMousePosition);
            // var playerPosition = Transform.position;
            // var playerViewVector = (Vector2)gameObject.transform.right;
            // var expectedPlayerView = worldMousePosition - new Vector2(playerPosition.x, playerPosition.y);
            // var rotationAngle = Vector2.SignedAngle(playerViewVector, expectedPlayerView);
            // Transform.Rotate(Vector3.forward, rotationAngle, Space.World);
        }

        public Player(GameObject player, int health = 100, int mana = 100, float speed = 10)
        { }
    }
}