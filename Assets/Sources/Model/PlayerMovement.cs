using UnityEngine;

namespace Sources.Model
{
    public class PlayerMovement
    {
        private readonly Player _player;
        private const float Speed = 2;

        public PlayerMovement(Player player)
        {
            _player = player;
        }

        public Vector3 Position => _player.Position;

        public void MovePassage(float targetXPosition)
        {
            _player.MovePassage(targetXPosition);
        }

        public void Tick(float delta)
        {
            float targetZ = _player.Position.z + Speed * delta;
            _player.MoveForward(targetZ);
        }
    }
}