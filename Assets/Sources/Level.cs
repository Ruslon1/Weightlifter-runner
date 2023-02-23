using UnityEngine;

namespace Sources
{
    public class Level : MonoBehaviour
    {
        public SpawnPoint[] GetSpawnPoints()
        {
            return GetComponentsInChildren<SpawnPoint>();
        }
    }
}