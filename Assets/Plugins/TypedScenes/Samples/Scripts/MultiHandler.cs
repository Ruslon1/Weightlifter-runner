using IJunior.TypedScenes;
using UnityEngine;

public class MultiHandler : MonoBehaviour, ISceneLoadHandler<float>, ISceneLoadHandler<bool>
{
    public void OnSceneLoaded(float levelIndex)
    {
        Debug.Log(levelIndex);
    }

    public void OnSceneLoaded(bool levelIndex)
    {
        Debug.Log(levelIndex);
    }
}
