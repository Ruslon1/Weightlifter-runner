using UnityEngine;

namespace Sources.View
{
    public class BarbellDiskTransformableView : TransformableView
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_rigidbody.isKinematic)
                transform.position = Model.Position;
        }
    }
}