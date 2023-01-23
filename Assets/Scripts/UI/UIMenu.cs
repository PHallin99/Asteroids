using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private UIUpdater uIUpdater;
        
        [SerializeField] private GameObject menuUI;
        [SerializeField] private GameObject gameGameObjects;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private TMP_Text lastGameScore;

        private void Start()
        {
            highScoreText.text = "High Score: " + scoreManager.LocalHighScore;
            lastGameScore.text = "Last Game: " + scoreManager.LastGameScore;
        }

        public void StartGame()
        {
            gameGameObjects.SetActive(true);
            gameUI.SetActive(true);
            menuUI.SetActive(false);
            uIUpdater.ToggleMouse();
        }

        public void GameOverUI()
        {
            gameOverUI.SetActive(true);
        }

        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}