using System.Collections.Generic;
using UnityEngine;

namespace Sources.Model.Barbell
{
    public class BarbellDiskExplosion
    {
        private readonly BarbellDisk _barbellDisk;
        private readonly ParticleSystem[] _explosionEffects;

        public BarbellDiskExplosion(BarbellDisk barbellDisk, ParticleSystem[] explosionEffects)
        {
            _barbellDisk = barbellDisk;
            _explosionEffects = explosionEffects;
            OnEnable();
        }

        private void OnEnable()
        {
            _barbellDisk.Explosion += OnExplosion;
        }

        private void OnDisable()
        {
            _barbellDisk.Explosion -= OnExplosion;
        }

        private void OnExplosion()
        {
            foreach (var effect in _explosionEffects)
            {
                effect.transform.SetParent(effect.transform);
                effect.Play();
            }
            
            OnDisable();
        }
    }
}