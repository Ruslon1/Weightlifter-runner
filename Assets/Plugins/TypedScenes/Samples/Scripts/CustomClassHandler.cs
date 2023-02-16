using UnityEngine;
using IJunior.TypedScenes;

public class CustomClassHandler : MonoBehaviour, ISceneLoadHandler<ExampleSceneLoadModel>
{
    public void OnSceneLoaded(ExampleSceneLoadModel levelIndex)
    {
        Debug.Log(levelIndex.ToString());
    }
}
