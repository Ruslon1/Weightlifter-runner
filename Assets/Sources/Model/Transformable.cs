using UnityEngine;

namespace Sources.Model
{
    public abstract class Transformable
    {
        public Transformable(Quaternion rotation, Vector3 position)
        {
            Position = position;
            Rotation = rotation;
        }

        public virtual Vector3 Position { get; protected set; }
        public Quaternion Rotation { get; }

        public virtual void TriggerEnter(Collider other)
        {
        }
    }
}