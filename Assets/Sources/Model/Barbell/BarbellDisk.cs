using System;
using UnityEngine;

namespace Sources.Model.Barbell
{
    public class BarbellDisk : Unit
    {
        private readonly Sources.Barbell _barbell;
        private readonly GameObject _instance;
        private readonly Transformable _player;
        private readonly Rigidbody _rigidbody;
        private bool _onBarbell;
        private SpawnPoint _spawnPoint;

        public BarbellDisk(Quaternion rotation, Vector3 position, Transformable player, Sources.Barbell barbell,
            GameObject instance)
            : base(rotation, position)
        {
            _player = player;
            _barbell = barbell;
            _instance = instance;
            _rigidbody = _instance.GetComponent<Rigidbody>();
        }

        public event Action Explosion;

        public override void TriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag(nameof(Player.Player))) AddDiskToBarbell();
        }

        public void Update()
        {
            if (_onBarbell) Position = _spawnPoint.transform.position;
        }

        public void LoseDisk()
        {
            _onBarbell = false;
            _rigidbody.isKinematic = false;
            Explosion?.Invoke();
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