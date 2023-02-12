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
            Debug.Log(_barbellDisks.Count);
            _barbellDisks.Add(_barbellDisks.Count + 1, model);
            return _barbellDiskPoints[_barbellDisks.Count + 1];
        }
    }
}