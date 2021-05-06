using InputSystem;
using UnityEngine;

namespace UnitsClasses
{
    public class PlayerMoving : UnitMoving
    {
        private Camera cameraForMouseDetecting;
        private PlayerControll controller;
        private Vector2 lastPositionOfMouse;
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

        private new void OnDisable() => controller.Disable();

        private new void OnCollisionExit2D(Collision2D other)
        { }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            RotateByMousePosition(lastPositionOfMouse);
            Move(MovingDirection); //Без этого столкновение неправильно меняет скорость игрока
            if (Rigidbody.velocity != Vector2.zero && !isMoving)
            {
                Rigidbody.drag = 5f;
            }
        }

        private void RotateByMousePosition(Vector2 screenMousePosition)
        {
            lastPositionOfMouse = screenMousePosition;
            var worldMousePosition = (Vector2)cameraForMouseDetecting.ScreenToWorldPoint(screenMousePosition);
            var playerPosition = transform.position;
            var playerViewVector = (Vector2)transform.right;
            var expectedPlayerView = worldMousePosition - new Vector2(playerPosition.x, playerPosition.y);
            var rotationAngle = Vector2.SignedAngle(playerViewVector, expectedPlayerView);
            transform.Rotate(Vector3.forward, rotationAngle, Space.World);
        }
        
        private new void Move(Vector2 direction)
        {
            MovingDirection = direction;
            isMoving = direction != Vector2.zero;
            base.Move(MovingDirection);
        }
    }
}