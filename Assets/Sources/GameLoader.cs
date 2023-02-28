using System;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;

namespace Sources
{
    public class GameLoader : MonoBehaviour, ISceneLoadHandler<int>
    {
        [SerializeField] private List<Level> _levels;

        public int CurrentLevelIndex { get; private set; }
        
        public void OnSceneLoaded(int levelIndex)
        {
            if (levelIndex > _levels.Count)
                throw new ArgumentException("The specified index is greater than necessary");

            CurrentLevelIndex = levelIndex;
            Instantiate(_levels[levelIndex - 1]);
        }
    }
}