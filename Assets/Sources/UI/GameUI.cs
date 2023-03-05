using IJunior.TypedScenes;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _pauseCanvas;

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
}