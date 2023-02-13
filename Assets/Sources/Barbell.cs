using System;
using System.Collections.Generic;
using Sources.Model.Barbell;
using UnityEngine;

namespace Sources
{
    public class Barbell : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _barbellDiskPoints;

        private readonly Dictionary<int, BarbellDisk> _barbellDisks = new();

        public SpawnPoint GetSpawnPointForNewDisk(BarbellDisk model)
        {
            if (_barbellDiskPoints.Count < _barbellDisks.Count + 1)
                throw new InvalidOperationException("Barbell disk count raised its maximum value");
            
            _barbellDisks.Add(_barbellDisks.Count + 1, model);
            return _barbellDiskPoints[_barbellDisks.Count - 1];
        }
    }
}