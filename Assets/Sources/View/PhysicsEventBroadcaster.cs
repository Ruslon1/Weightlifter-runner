using Sources.Model;
using UnityEngine;

namespace Sources.View
{
    public class PhysicsEventBroadcaster : MonoBehaviour
    {
        private Transformable _model;

        private void OnTriggerEnter(Collider other)
        {
            _model.TriggerEnter(other);
        }

        public void Init(Transformable model)
        {
            _model = model;
        }
    }
}