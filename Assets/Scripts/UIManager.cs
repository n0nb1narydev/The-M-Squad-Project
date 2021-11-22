using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text waveText;
    public Text timerText;
    public Text finalScoreText;

    public void Start()
    {
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateWaveText(int wave)
    {
        waveText.text = "Wave " + wave + "/5";
    }

    public void UpdateTimerText(int seconds)
    {
        timerText.text = "Time Remaining: " + seconds;
    }
   
    public void UpdateLivesText(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateFinalScoreText(int finalScore)
    {
        finalScoreText.text = "Final Score: " + finalScore;
    }
}
