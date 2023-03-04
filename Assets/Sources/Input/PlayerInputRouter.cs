using Sources.Model.Player;
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

        private Camera Camera => Camera.main;

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
            currentMousePosition.z = Vector3.Distance(_playerMovement.Position, Camera.transform.position);
            var targetXPosition = Camera.ScreenToWorldPoint(currentMousePosition).x;

            if (CanMove(targetXPosition))
                _playerMovement.MovePassage(targetXPosition);
        }

        private bool CanMove(float targetX)
        {
            return targetX - _playerMovement.Position.x is > -1.5f and < 1.5f;
        }
    }
}