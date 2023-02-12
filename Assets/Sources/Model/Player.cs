using UnityEngine;

namespace Sources.Model
{
    public class Player : Transformable
    {
        public override Vector3 Position { get; protected set; }

        public Player(Vector3 position, Quaternion rotation) : base(rotation, position)
        {
        }

        public void MoveForward(float targetZ)
        {
            Vector3 targetPosition = new(Position.x, Position.y, targetZ);
            Position = targetPosition;
        }

        public void MovePassage(float targetXPosition)
        {
            Position = new Vector3(targetXPosition, Position.y, Position.z);
        }
    }
}