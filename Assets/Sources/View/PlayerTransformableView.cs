using UnityEngine;

namespace Sources.View
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTransformableView : TransformableView
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_rigidbody.isKinematic == false)
                return;

            transform.position = Model.Position;
            transform.rotation = Model.Rotation;
        }
    }
}