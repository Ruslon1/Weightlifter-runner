using UnityEngine;

namespace Sources
{
    public sealed class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Side _side;

        public Side Side => _side;
    }

    public enum Side
    {
        Right,
        Left
    }
}