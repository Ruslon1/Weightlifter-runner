using System;
using IJunior.TypedScenes;
using Sources;
using Sources.Model.Player;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Canvas _loseCanvas;
    [SerializeField] private GameLoader _gameLoader;
    [SerializeField] private SceneLoadRouter _sceneLoadRouter;

    private Player _player;

    public void Init(Player player)
    {
        _player = player;
        _player.Falling += ShowLosingUI;
    }

    private void OnDisable()
    {
        _player.Falling -= ShowLosingUI;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _mainCanvas.gameObject.SetActive(false);
        _pauseCanvas.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _mainCanvas.gameObject.SetActive(true);
        _pauseCanvas.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        Menu.Load();
    }

    public void ReloadLevel()
    {
        _sceneLoadRouter.LoadGame(_gameLoader.CurrentLevelIndex);
    }

    private void ShowLosingUI()
    {
        _mainCanvas.gameObject.SetActive(false);
        _loseCanvas.gameObject.SetActive(true);
    }
}