using System;
using Sources.Model;
using Sources.Model.Barbell;
using UnityEngine;

namespace Sources.View
{
    public class PhysicsEventBroadcaster : MonoBehaviour
    {
        private Transformable _model;

        public void Init(Transformable model)
        {
            _model = model;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _model.TriggerEnter(other);
        }
    }
}