﻿using IJunior.TypedScenes;
using UnityEngine;

public class StringHandler : MonoBehaviour, ISceneLoadHandler<string>
{
    public void OnSceneLoaded(string levelIndex)
    {
        Debug.Log(levelIndex);
    }
}
