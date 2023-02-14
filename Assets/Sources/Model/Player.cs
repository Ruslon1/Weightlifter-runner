using System;
using UnityEngine;

namespace Sources.Model
{
    public class Player : Transformable
    {
        private StateOfMovement _stateOfMovement = StateOfMovement.Idle;
        
        public override Vector3 Position { get; protected set; }

        public Player(Vector3 position, Quaternion rotation) : base(rotation, position)
        {
        }

        public event Action<StateOfMovement> ChangedStateOfMovement;

        public void MoveForward(float targetZ)
        {
            if(_stateOfMovement is not StateOfMovement.RunningForward)
                ChangedStateOfMovement?.Invoke(StateOfMovement.RunningForward);
            
            Vector3 targetPosition = new(Position.x, Position.y, targetZ);
            Position = targetPosition;
        }

        public void MovePassage(float targetXPosition)
        {
            Position = new Vector3(targetXPosition, Position.y, Position.z);
        }
    }
}