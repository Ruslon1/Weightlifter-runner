using System.Collections.Generic;
using UnityEngine;

namespace Sources.CompositeRoot
{
    class CompositionOrder : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _compositions;

        private void Awake()
        {
            foreach (var composition in _compositions)
            {
                composition.Compose();
                composition.enabled = true;
            }
        }
    }
}