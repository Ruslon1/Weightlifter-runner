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

        public BarbellDisk(Quaternion rotation, Vector3 position, Transformable player, Sources.Barbell barbell,
            GameObject instance)
            : base(rotation, position)
        {
            _player = player;
            _barbell = barbell;
            _instance = instance;
            _rigidbody = _instance.GetComponent<Rigidbody>();
        }

        public SpawnPoint SpawnPoint { get; private set; }

        public event Action Explosion;

        public override void TriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag(nameof(Player.Player))) AddDiskToBarbell();
        }

        public void LateUpdate()
        {
            if (_onBarbell)
            {
                Position = SpawnPoint.transform.position;
                Rotation = SpawnPoint.transform.rotation;
            }
        }

        public void LoseDisk()
        {
            _onBarbell = false;
            _rigidbody.isKinematic = false;
            _instance.transform.parent = null;
            Explosion?.Invoke();
        }

        private void AddDiskToBarbell()
        {
            try
            {
                SpawnPoint = _barbell.GetSpawnPointForNewDisk(this);
            }
            catch (Exception e)
            {
                Explosion?.Invoke();
                Disable();
                return;
            }

            _instance.transform.parent = SpawnPoint.transform;
            _onBarbell = true;
        }

        private void Disable()
        {
            _instance.SetActive(false);
        }
    }
}