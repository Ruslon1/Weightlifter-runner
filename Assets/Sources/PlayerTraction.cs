using Sources.View;
using UnityEngine;

namespace Sources
{
    public class PlayerTraction : MonoBehaviour
    {
        [SerializeField] private PlayerTransformableView _playerView;
        [SerializeField] private Vector3 _offset;

        private void LateUpdate()
        {
            Vector3 targetPosition = _playerView.transform.position + _offset;
            targetPosition.x = transform.position.x;
        
            transform.position = targetPosition;
        }
    }
}
