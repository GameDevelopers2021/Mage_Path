﻿using CodeSources.Scripts.Units;
using UnityEngine;

namespace CodeSources.Model.Units
{
    public class Player : UnitBase
    {
        public Player(MonoBehaviour unitScript, int health = 100, int mana = 100, float speed = 10)
            : base(unitScript, health, mana, speed, "Player")
        {
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