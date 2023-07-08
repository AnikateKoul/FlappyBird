using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public BirdScript birdScript;
    public Text gameScore;
    public Text gameHighScore;

    private void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    private void Update()
    {
        if(!birdScript.isBirdAlive)
        {
            gameOver();
        }
    }

    [ContextMenu("Add Score")]
    public void addScore(int score)
    {
        if(birdScript.isBirdAlive)
        {
            playerScore += score;
            scoreText.text = playerScore.ToString();
            gameScore.text = $"Score : {playerScore}";
        }
    }

    public void RestartGame()
    {
        Console.Write("Game restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            int temp = PlayerPrefs.GetInt("HighScore");
            if (temp < playerScore)
            {
                temp = playerScore;
            }
            PlayerPrefs.SetInt("HighScore", temp);
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        int highScore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.Save();
        gameHighScore.text = $"High Score : {highScore}";
        gameOverScreen.SetActive(true);
    }
}
