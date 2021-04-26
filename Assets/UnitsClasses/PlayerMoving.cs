using System;
using InputSystem;
using UnitsInterfaces;
using UnityEngine;

namespace UnitsClasses
{
    public class PlayerMoving : UnitComponent
    {
        public float Speed { get; } = 8f;
        private Camera cameraForMouseDetecting;
        private PlayerControll controller;
        private Vector2 lastPositionOfMouse;
        private Vector2 lastMovingDirection;
        private bool isMoving;

        private new void Awake()
        {
            base.Awake();
            cameraForMouseDetecting = Camera.main;
            controller = new PlayerControll();
            var actions = controller.Player;
            actions.MouseMoving.performed += context => RotateByMousePosition(context.ReadValue<Vector2>());
            actions.Moving.performed += context => Move(context.ReadValue<Vector2>());
            actions.Moving.canceled += context => Move(Vector2.zero);
        }

        private void OnEnable() => controller.Enable();

        private void OnDisable() => controller.Disable();

        private void FixedUpdate()
        { 
           RotateByMousePosition(lastPositionOfMouse);
           Move(lastMovingDirection); //Без этого столкновение неправильно меняет скорость игрока
           Rigidbody.angularVelocity = 0f;
           if (Rigidbody.velocity != Vector2.zero && !isMoving)
               Rigidbody.drag = 5f;
        }

        private void RotateByMousePosition(Vector2 screenMousePosition)
        {
            lastPositionOfMouse = screenMousePosition;
            var worldMousePosition = (Vector2)cameraForMouseDetecting.ScreenToWorldPoint(screenMousePosition);
            var playerPosition = Transform.position;
            var playerViewVector = (Vector2)Transform.right;
            var expectedPlayerView = worldMousePosition - new Vector2(playerPosition.x, playerPosition.y);
            var rotationAngle = Vector2.SignedAngle(playerViewVector, expectedPlayerView);
            Transform.Rotate(Vector3.forward, rotationAngle, Space.World);
        }
        
        private void Move(Vector2 direction)
        {
            lastMovingDirection = direction;
            if (direction == Vector2.zero)
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
            Rigidbody.drag = 0f;
            Rigidbody.velocity = direction.normalized * Speed;
        }
    }
}