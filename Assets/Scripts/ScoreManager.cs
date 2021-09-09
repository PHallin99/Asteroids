using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string highScoreKey;
    [SerializeField] private string lastGameKey;

    public int LastGameScore { get; private set; }

    public int LocalHighScore { get; private set; }

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

        if (score <= LocalHighScore) return false;
        UpdateLocalHighScore(score);
        return true;

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