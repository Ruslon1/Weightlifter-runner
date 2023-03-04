using Sources.Input;
using Sources.Model.Player;
using Sources.UI;
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
        [SerializeField] private FinishUI _finishUI;

        private Player _player;
        private PlayerAnimation _playerAnimation;
        private PlayerInputRouter _playerInputRouter;
        private PlayerMovement _playerMovement;

        private void Update()
        {
            _playerInputRouter.Update();
            _playerMovement.Tick(Time.deltaTime);
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

        public override void Compose()
        {
            _player = new Player(_defaultPlayerPosition, Quaternion.identity);
            _playerMovement = new PlayerMovement(_player);
            _playerInputRouter = new PlayerInputRouter(_playerMovement);
            _playerAnimation = new PlayerAnimation(_animator, _player);

            _physicsEventBroadcaster.Init(_player);
            _playerTransformableView.Init(_player);
            _finishUI.Init(_player);
        }
    }
}