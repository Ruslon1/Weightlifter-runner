using System;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;

namespace Sources
{
    public class GameLoader : MonoBehaviour, ISceneLoadHandler<int>
    {
        [SerializeField] private List<Level> _levels;
        
        public void OnSceneLoaded(int levelIndex)
        {
            if (levelIndex > _levels.Count)
                throw new ArgumentException("The specified index is greater than necessary");
            
            Instantiate(_levels[levelIndex - 1]);
        }
    }
}