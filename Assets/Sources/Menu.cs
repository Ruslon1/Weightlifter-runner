using UnityEngine;

namespace Sources
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Canvas _startCanvas;
        [SerializeField] private Canvas _levelChooseCanvas;
        
        public void EnableLevelChooseCanvas()
        {
            _startCanvas.gameObject.SetActive(false);
            _levelChooseCanvas.gameObject.SetActive(true);
        }
    }
}
