using System;
using Sources.Input;
using Sources.Model;
using Sources.View;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class PlayerCompositeRoot : CompositeRoot
    {
        [SerializeField] private PlayerTransformableView _playerTransformableView;
        [SerializeField] private Vector3 _defaultPlayerPosition;

        private Player _player;
        private PlayerMovement _playerMovement;
        private PlayerInputRouter _playerInputRouter;

        public override void Compose()
        {
            _player = new Player(_defaultPlayerPosition, Quaternion.identity);
            _playerMovement = new PlayerMovement(_player);
            _playerInputRouter = new PlayerInputRouter(_playerMovement);

            _playerTransformableView.Init(_player);
        }

        private void OnEnable()
        {
            _playerInputRouter.OnEnable();
        }

        private void OnDisable()
        {
            _playerInputRouter.OnDisable();
        }

        private void Update()
        {
            _playerInputRouter.Update();
            _playerMovement.Tick(Time.deltaTime);
        }
    }
}