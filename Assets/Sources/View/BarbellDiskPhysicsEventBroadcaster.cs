using System;
using Sources.Model.Barbell;
using UnityEngine;

namespace Sources.View
{
    public class BarbellDiskPhysicsEventBroadcaster : MonoBehaviour
    {
        private BarbellDisk _disk;

        public void Init(BarbellDisk disk)
        {
            _disk = disk;
        }
        private void OnTriggerEnter(Collider other)
        {
            _disk.TriggerEnter(other);
        }
    }
}