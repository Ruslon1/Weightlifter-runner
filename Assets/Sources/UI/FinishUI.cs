using System;
using System.Collections;
using Sources.Model.Player;
using UnityEngine;

namespace Sources.UI
{
    public class FinishUI : MonoBehaviour
    {
        [SerializeField] private Canvas _finishCanvas;
        [SerializeField] private GameLoader _gameLoader;
        [SerializeField] private SceneLoadRouter _sceneLoadRouter;

        private Player _player;

        private void OnDisable()
        {
            _player.Finished -= OnFinished;
        }

        public void Init(Player player)
        {
            _player = player;
            _player.Finished += OnFinished;
        }

        public void LoadNextLevel()
        {
            try
            {
                _sceneLoadRouter.LoadGame(_gameLoader.CurrentLevelIndex + 1);
            }
            catch (Exception e)
            {
                IJunior.TypedScenes.Menu.Load();
            }
        }

        private void OnFinished()
        {
            StartCoroutine(nameof(ShowFinishCanvas));
        }

        private IEnumerator ShowFinishCanvas()
        {
            yield return new WaitForSeconds(1);
            _finishCanvas.gameObject.SetActive(true);
        }
    }
}