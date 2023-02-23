using System;
using Sources.Input;
using Sources.Model;
using Sources.Model.Player;
using Sources.View;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class PlayerCompositeRoot : CompositeRoot
    {
        [SerializeField] private PlayerTransformableView _playerTransformableView;
        [SerializeField] private Vector3 _defaultPlayerPosition;
        [SerializeField] private Animator _animator;
        [SerializeField] private PhysicsEventBroadcaster _physicsEventBroadcaster;

        private Player _player;
        private PlayerMovement _playerMovement;
        private PlayerInputRouter _playerInputRouter;
        private PlayerAnimation _playerAnimation;

        public override void Compose()
        {
            _player = new Player(_defaultPlayerPosition, Quaternion.identity);
            _playerMovement = new PlayerMovement(_player);
            _playerInputRouter = new PlayerInputRouter(_playerMovement);
            _playerAnimation = new PlayerAnimation(_animator, _player);
            
            _physicsEventBroadcaster.Init(_player);
            _playerTransformableView.Init(_player);
        }

        private void OnEnable()
        {
            _playerInputRouter.OnEnable();
            _playerAnimation.OnEnable();
        }

        private void OnDisable()
        {
            _playerInputRouter.OnDisable();
            _playerAnimation.OnDisable();
        }

        private void Update()
        {
            _playerInputRouter.Update();
            _playerMovement.Tick(Time.deltaTime);
        }
    }
}