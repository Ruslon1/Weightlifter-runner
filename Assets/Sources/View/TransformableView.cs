using Sources.Model;
using UnityEngine;

namespace Sources.View
{
    public abstract class TransformableView : MonoBehaviour
    {
        public Transformable Model { get; private set; }

        public void Init(Transformable model)
        {
            Model = model;
        }
    }
}