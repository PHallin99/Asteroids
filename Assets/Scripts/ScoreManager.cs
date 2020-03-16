using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] string highScoreKey;
	[SerializeField] string lastGameKey;
	private int localHighScore;
	private int lastGameScore;

	public int LastGameScore
	{
		get
		{
			return lastGameScore;
		}

		set
		{
			lastGameScore = value;
		}
	}

	public int LocalHighScore
	{
		get
		{
			return localHighScore;
		}

		set
		{
			localHighScore = value;
		}
	}

	private void Start()
	{
		CheckLocalHighScore();
		CheckLastGameScore();
	}

	private void CheckLocalHighScore()
	{
		LocalHighScore = PlayerPrefs.GetInt(highScoreKey, 0);
	}

	private void CheckLastGameScore()
	{
		// Checks last game score to int
		LastGameScore = PlayerPrefs.GetInt(lastGameKey, 0);
	}

	public bool CheckScore(int score)
	{
		// Checks if the score is higher than the local highscore - Calls UpdateLocalHighScore if score was higher than localHighScore
		// Also updates last game score value that is stored
		UpdateLastGameScore(score);

		if (score > LocalHighScore)
		{
			UpdateLocalHighScore(score);
			return true;
		}

		return false;
	}

	private void UpdateLocalHighScore(int score)
	{
		// Updates the locally saved highscore to the score
		PlayerPrefs.SetInt(highScoreKey, score);
	}

	private void UpdateLastGameScore(int score)
	{
		PlayerPrefs.SetInt(lastGameKey, score);
	}

	public void ResetScores()
	{
		PlayerPrefs.DeleteAll();
	}
}
