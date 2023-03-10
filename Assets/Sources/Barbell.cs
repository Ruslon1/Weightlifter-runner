using System;
using System.Collections.Generic;
using Sources.Model.Barbell;
using Sources.View;
using UnityEngine;

namespace Sources
{
    public class Barbell : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _barbellDiskPoints;

        private readonly Queue<BarbellDisk> _barbellDisks = new();

        public SpawnPoint GetSpawnPointForNewDisk(BarbellDisk model)
        {
            if (_barbellDiskPoints.Count < _barbellDisks.Count + 1)
                throw new InvalidOperationException("Barbell disk count raised its maximum value");
            
            _barbellDisks.Enqueue(model);
            return GetFreeSpawnPoint();
        }

        public void LoseHalfOfDisks()
        {
            var halfAmountOfBarbellDisks = _barbellDisks.Count / 2;

            for (var i = 0; i < halfAmountOfBarbellDisks; i++)
            {
                var disk = _barbellDisks.Dequeue();
                disk.LoseDisk();
            }
        }

        private SpawnPoint GetFreeSpawnPoint()
        {
            foreach (var point in _barbellDiskPoints)
            {
                if (point.GetComponentInChildren<BarbellDiskTransformableView>() is null)
                    return point;
            }

            return null;
        }
    }
}