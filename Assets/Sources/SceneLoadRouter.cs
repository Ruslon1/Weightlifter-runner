using IJunior.TypedScenes;
using UnityEngine;

namespace Sources
{
    public class SceneLoadRouter : MonoBehaviour
    {
        public void LoadGame(int levelIndex)
        {
            Main.Load(levelIndex);
        }
    }
}