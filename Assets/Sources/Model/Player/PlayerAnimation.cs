using UnityEngine;

namespace Sources.Model.Player
{
    public class PlayerAnimation
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");

        public static bool FinishAnimationCompleted;
        private readonly Animator _animator;
        private readonly Player _player;

        public PlayerAnimation(Animator animator, Player player)
        {
            _animator = animator;
            _player = player;
        }

        public void OnEnable()
        {
            _player.ChangedStateOfMovement += OnChangedStateOfMovement;
            _player.Finished += OnFinished;
        }

        public void OnDisable()
        {
            _player.ChangedStateOfMovement -= OnChangedStateOfMovement;
            _player.Finished -= OnFinished;
        }

        private void OnChangedStateOfMovement(StateOfMovement state)
        {
            if (state is StateOfMovement.RunningForward) _animator.SetBool(IsRunning, true);
            if (state is StateOfMovement.Idle) _animator.SetBool(IsRunning, false);
        }

        private void OnFinished()
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetBool("isPunching_Right", true);
            _animator.SetTrigger("Finishing");
        }
    }
}