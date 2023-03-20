using UnityEngine;

namespace Sources.Model.Player
{
    public class PlayerMovement
    {
        private const float Speed = 8;
        private readonly Player _player;

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
            var targetZ = _player.Position.z + Speed * delta;
            _player.MoveForward(targetZ);
        }
    }
}