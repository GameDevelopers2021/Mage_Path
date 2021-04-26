using InputSystem;
using UnityEngine;

namespace UnitsClasses
{
    public class PlayerMoving : UnitComponent
    {
        public float Speed { get; } = 5f;
        private Camera cameraForMouseDetecting;
        private PlayerControll controller;
        private Vector2 lastPositionOfMouse;
        private Vector2 velocity;
        
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
           Rigidbody.angularVelocity = 0f;
           Rigidbody.velocity = velocity;
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
            velocity = direction.normalized * Speed;
        }
    }
}