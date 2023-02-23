using System;
using UnityEngine;

namespace Sources.Model.Player
{
    public class Player : Transformable
    {
        private StateOfMovement _stateOfMovement = StateOfMovement.Idle;
        private bool _canMove = true;
        
        public override Vector3 Position { get; protected set; }

        public Player(Vector3 position, Quaternion rotation) : base(rotation, position)
        {
            Finished += OnFinish;
        }

        public event Action<StateOfMovement> ChangedStateOfMovement;
        public event Action Finished; 

        public void MoveForward(float targetZ)
        {
            if(_canMove == false)
                return;
            
            if(_stateOfMovement is not StateOfMovement.RunningForward)
                ChangedStateOfMovement?.Invoke(StateOfMovement.RunningForward);
            
            Vector3 targetPosition = new(Position.x, Position.y, targetZ);
            Position = targetPosition;
        }

        public void MovePassage(float targetXPosition)
        {
            if(_canMove == false)
                return;
            
            Position = new Vector3(targetXPosition, Position.y, Position.z);
        }

        public override void TriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Finish.Finish finish))
            {
                Finished?.Invoke();
            }
        }

        private void OnFinish()
        {
            _canMove = false;
        }
    }
}