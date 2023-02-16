using IJunior.TypedScenes;
using UnityEngine;

public class IntHandler : MonoBehaviour, ISceneLoadHandler<int>
{
    public void OnSceneLoaded(int levelIndex)
    {
        Debug.Log(levelIndex.ToString());
    }
}
