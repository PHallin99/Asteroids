using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject[] lifeUIObjects;
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private ScoreManager scoreManager;
	[SerializeField] private AsteroidSpawner asteroidSpawner;

	[SerializeField] private GameObject highScoreBeatUI;
	[SerializeField] private TMP_Text gameOverScoreText;

	private UIMenu uIMenu;

	private CursorLockMode cursorLockMode;

	private int selectedUIObject = 0;
	private int score = 0;

	private void Start()
	{
		uIMenu = GetComponent<UIMenu>();
		scoreText.text = score.ToString();
	}

	public void RemoveLife()
	{
		lifeUIObjects[selectedUIObject].SetActive(false);
		selectedUIObject++;

		if (selectedUIObject > 2)
		{
			asteroidSpawner.OnGameOver();
			uIMenu.GameOverUI();
			ToggleMouse();
			GameOver();
		}
	}

	public void AddScore(int scoreToAdd)
	{
		score = score + scoreToAdd;

		scoreText.text = score.ToString();
	}

	private void GameOver()
	{
		// If highscore was beat, update it and show text saying user beat highscore
		scoreText.gameObject.SetActive(false);
		player.SetActive(false);
		if (scoreManager.CheckScore(score))
		{
			highScoreBeatUI.SetActive(true);
			gameOverScoreText.text = score.ToString();
		}
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
			default:
				break;
		}
	}
}
