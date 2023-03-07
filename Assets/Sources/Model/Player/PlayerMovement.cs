using UnityEngine;

namespace Sources.Model.Player
{
    public class PlayerMovement
    {
        private const float Speed = 2;
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
            Ray ray = new Ray(new Vector3(Position.x, Position.y + 1, Position.z), Vector3.down);
            
            if (Physics.Raycast(ray, 10) == false)
                _player.FallDown();
                
            var targetZ = _player.Position.z + Speed * delta;
            _player.MoveForward(targetZ);
        }
    }
}