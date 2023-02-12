using UnityEngine;

namespace Sources.Model.Barbell
{
    public class BarbellDisk : Unit
    {
        private readonly Transformable _player;
        private readonly Sources.Barbell _barbell;
        private bool _onBarbell;
        private SpawnPoint _spawnPoint;

        public BarbellDisk(Quaternion rotation, Vector3 position, Transformable player, Sources.Barbell barbell) 
            : base(rotation, position)
        {
            _player = player;
            _barbell = barbell;
        }

        public void TriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag(nameof(Player)))
            {
                Debug.Log("Player");
                AddDiskToBarbell();
            }
        }

        public void Update()
        {
            if (_onBarbell)
            {
                Position = _spawnPoint.transform.position;
            }
        }

        private void AddDiskToBarbell()
        {
            _spawnPoint = _barbell.GetSpawnPointForNewDisk(this);
            _onBarbell = true;
        }
    }
}