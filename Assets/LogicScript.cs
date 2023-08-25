using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public float playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public float highScore;
    public Text highScoreText;
    private bool isGameOver;

    [ContextMenu("Increase Score")]
    
    public void addScore(int scoreToAdd)
    {
        if(isGameOver == false)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            setHighScore();
        }
    }

    public float GetScore()
    {
        return playerScore;
    }

    public void setHighScore()
    {
        if (playerScore > PlayerPrefs.GetFloat("highScore",0))
        {
            highScore = playerScore;
            PlayerPrefs.SetFloat("highScore", highScore);
            PlayerPrefs.Save();
            showHighScore();
        }
    }

    public void showHighScore()
    {
        highScoreText.text = PlayerPrefs.GetFloat("highScore", 0).ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }
}
