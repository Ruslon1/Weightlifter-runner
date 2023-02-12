using Sources.Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Input
{
    public class PlayerInputRouter
    {
        private readonly PlayerInput _playerInput;
        private readonly PlayerMovement _playerMovement;
        private Vector3 _previousMousePosition;

        public PlayerInputRouter(PlayerMovement playerMovement)
        {
            _playerInput = new PlayerInput();
            _playerMovement = playerMovement;
        }

        private Camera _camera => Camera.main;

        public void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Touch.Tracktion.performed += Tracking;
        }

        public void OnDisable()
        {
            _playerInput.Disable();
        }

        public void Update()
        {
        }

        private void Tracking(InputAction.CallbackContext context)
        {
            Vector3 currentMousePosition = context.ReadValue<Vector2>();
            currentMousePosition.z = 10;
            float targetXPosition = _camera.ScreenToWorldPoint(currentMousePosition).x;

            if (CanMove(targetXPosition))
                _playerMovement.MovePassage(targetXPosition);
        }

        private bool CanMove(float targetX)
        {
            return targetX - _playerMovement.XPosition is > -1.5f and < 1.5f;
        }
    }
}