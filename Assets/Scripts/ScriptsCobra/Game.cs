using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public Text hscoreText;
    public int score;
    public int hScore;

    public GameObject gameOverPanel, StartPanel;

    public void SetScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        StartPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        if(score > hScore)
        {
            PlayerPrefs.SetInt("HScore", score);
            hscoreText.text = "New H-Score" + score.ToString();

        }

        Time.timeScale = 0;

    }
}
