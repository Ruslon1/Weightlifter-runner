using System.Collections.Generic;
using UnityEngine;

namespace Sources.View
{
    public class UnitFactory : IFactory
    {
        private readonly SpawnPoint[] _spawnPoints;
        private readonly List<TransformableView> _units;

        public UnitFactory(SpawnPoint[] spawnPoints, List<TransformableView> units)
        {
            _spawnPoints = spawnPoints;
            _units = units;
        }

        public List<TransformableView> RandomSpawn()
        {
            var parity = Random.Range(1, 2);
            var items = new List<TransformableView>();

            for (var i = 0; i < _spawnPoints.Length; i += parity)
                items.Add(Object.Instantiate(_units[Random.Range(0, _units.Count)], _spawnPoints[i].transform));

            return items;
        }
    }
}