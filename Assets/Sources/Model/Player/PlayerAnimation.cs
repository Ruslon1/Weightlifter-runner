using UnityEngine;

namespace Sources.Model.Player
{
    public class PlayerAnimation
    {
        private readonly Animator _animator;
        private readonly Player _player;
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsFinishing = Animator.StringToHash("isPunching_Right");

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
            if (state is StateOfMovement.RunningForward)
            {
                _animator.SetBool(IsRunning, true);
            }
        }

        private void OnFinished()
        {
            Debug.Log("Anim");
            _animator.SetBool(IsRunning, false);
            _animator.SetBool("isPunching_Right", true);
        }
    }
}