using IJunior.TypedScenes;
using UnityEngine;

public class SceneLoadRouter : MonoBehaviour
{
    public void LoadGame(int levelIndex)
    {
        Main.Load(levelIndex);
    }
}
