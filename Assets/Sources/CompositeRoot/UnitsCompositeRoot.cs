using System.Collections.Generic;
using Sources.Model;
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
        
        private readonly List<BarbellDisk> _barbellDisks = new();

        private Level _level;
        private IFactory _unitFactory;
        private List<TransformableView> _units;

        private void LateUpdate()
        {
            _barbellDisks.ForEach(ctx => ctx.LateUpdate());
        }

        public override void Compose()
        {
            _level = FindObjectOfType<Level>();
            _unitFactory = new UnitFactory(_level.GetSpawnPoints(), _unitPrefabs);
            LaunchFactory();
            InitUnits();
        }

        private void LaunchFactory()
        {
            _units = _unitFactory.RandomSpawn();
        }

        private void InitUnits()
        {
            foreach (var unit in _units) InitConcreteUnits((dynamic)unit);
        }

        private void InitConcreteUnits(BarbellDiskTransformableView view)
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

        private void InitConcreteUnits(ObstacleTransformableView view)
        {
            var physicEventBroadCaster = view.GetComponent<PhysicsEventBroadcaster>();
            var model = new Obstacle(view.transform.rotation, view.transform.position, _barbell);

            physicEventBroadCaster.Init(model);
        }
    }
}