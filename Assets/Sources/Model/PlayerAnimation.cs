using UnityEngine;

namespace Sources.Model
{
    public class PlayerAnimation
    {
        private readonly Animator _animator;
        private readonly Player _player;
        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        public PlayerAnimation(Animator animator, Player player)
        {
            _animator = animator;
            _player = player;
        }

        public void OnEnable()
        {
            _player.ChangedStateOfMovement += OnChangedStateOfMovement;
        }

        public void OnDisable()
        {
            _player.ChangedStateOfMovement -= OnChangedStateOfMovement;
        }

        private void OnChangedStateOfMovement(StateOfMovement state)
        {
            if (state is StateOfMovement.RunningForward)
            {
                _animator.SetBool(IsRunning, true);
            }
        }
    }
}