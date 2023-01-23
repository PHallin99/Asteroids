using System;
using Asteroid;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIUpdater : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject[] lifeUIObjects;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private GameObject highScoreBeatUI;
        [SerializeField] private TMP_Text gameOverScoreText;

        private UIMenu uIMenu;
        private CursorLockMode cursorLockMode;
        private int score;
        private int selectedUIObject;

        private void Start()
        {
            uIMenu = GetComponent<UIMenu>();
            scoreText.text = score.ToString();
        }

        public void RemoveLife()
        {
            lifeUIObjects[selectedUIObject].SetActive(false);
            selectedUIObject++;

            if (selectedUIObject <= 2) return;
            uIMenu.GameOverUI();
            OnGameOver();
        }

        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = score.ToString();
        }

        private void OnGameOver()
        {
            ToggleMouse();
            scoreText.gameObject.SetActive(false);
            player.SetActive(false);
            gameOverScoreText.text = score.ToString();
            if (ScoreManager.Instance.CompareToHighScore(score))
                highScoreBeatUI.SetActive(true);
        }

        public void ToggleMouse()
        {
            switch (cursorLockMode)
            {
                case CursorLockMode.None:
                    cursorLockMode = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                case CursorLockMode.Locked:
                    cursorLockMode = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case CursorLockMode.Confined:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}