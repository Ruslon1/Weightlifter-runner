﻿using System.Collections.Generic;
using Sources.Model.Barbell;
using Sources.View;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class UnitsCompositeRoot : CompositeRoot
    {
        [SerializeField] private List<TransformableView> _unitPrefabs;
        [SerializeField] private PlayerTransformableView _playerTransformableView;
        [SerializeField] private Barbell _barbell;

        private Level _level;
        private IFactory _unitFactory;
        private List<TransformableView> _units;
        private readonly List<BarbellDisk> _barbellDisks = new();

        public override void Compose()
        {
            _level = FindObjectOfType<Level>();
            _unitFactory = new UnitFactory(_level.GetSpawnPoints(), _unitPrefabs);
            LaunchFactory();
            InitBarbellDisks();
        }

        private void LaunchFactory()
        {
            _units = _unitFactory.RandomSpawn();
        }

        private void InitBarbellDisks()
        {
            foreach (var unit in _units)
            {
                if (unit is BarbellDiskTransformableView view)
                {
                    var physicEventBroadCaster = view.GetComponent<PhysicsEventBroadcaster>();
                    var model = new BarbellDisk(view.transform.rotation, view.transform.position,
                        _playerTransformableView.Model, _barbell, view.gameObject);
                    var effectList = view.GetComponentsInChildren<ParticleSystem>();
                    var modelExplosion = new BarbellDiskExplosion(model, effectList);

                    view.Init(model);
                    physicEventBroadCaster.Init(model);

                    _barbellDisks.Add(model);
                }
            }
        }

        private void Update()
        {
            _barbellDisks.ForEach(ctx => ctx.Update());
        }
    }
}