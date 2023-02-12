using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public SpawnPoint[] GetSpawnPoints()
    {
        return GetComponentsInChildren<SpawnPoint>();
    }
}