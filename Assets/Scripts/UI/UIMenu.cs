using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMenu : MonoBehaviour
{
	[SerializeField] private GameObject menuUI;
	[SerializeField] private GameObject gameGameObjects;
	[SerializeField] private GameObject gameUI;
	[SerializeField] private GameObject gameOverUI;
	[SerializeField] private TMP_Text highScoreText;
	[SerializeField] private TMP_Text lastGameScore;
	[SerializeField] private ScoreManager scoreManager;

	private UIUpdater uIUpdater;

	private void Start()
	{
		highScoreText.text = "High Score: " + scoreManager.LocalHighScore.ToString();
		lastGameScore.text = "Last Game: " + scoreManager.LastGameScore.ToString();
	}


	public void StartGame()
	{
		// Remove menu UI and enble player, asteroid spawner and game UI and call ToggleMouse
		gameGameObjects.SetActive(true);
		gameUI.SetActive(true);
		menuUI.SetActive(false);

		uIUpdater = FindObjectOfType<UIUpdater>();
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
