using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Model.Barbell
{
    public class BarbellDisk : Unit
    {
        private readonly Transformable _player;
        private readonly Sources.Barbell _barbell;
        private bool _onBarbell;
        private SpawnPoint _spawnPoint;
        private readonly GameObject _instance;

        public BarbellDisk(Quaternion rotation, Vector3 position, Transformable player, Sources.Barbell barbell, GameObject instance)
            : base(rotation, position)
        {
            _player = player;
            _barbell = barbell;
            _instance = instance;
        }

        public event Action Explosion;

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
            try
            {
                _spawnPoint = _barbell.GetSpawnPointForNewDisk(this);
            }
            catch (Exception e)
            {
                Explosion?.Invoke();
                Disable();
                return;
            }
            _onBarbell = true;
        }

        private void Disable()
        {
            _instance.SetActive(false);
        }
    }
}