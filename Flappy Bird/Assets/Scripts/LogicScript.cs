using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public UnityEngine.UI.Button restartButton;
    public SpriteRenderer medal;
    public Sprite gold;
    public Sprite silver;
    public Sprite bronze;
    public AudioSource bgMusic;
    public bool isPaused;
    public GameObject pauseIcon;
    public bool birdIsAlive = true;

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
        
        if (score >= 11)
            medal.sprite = gold;
        else if (score >= 6)
            medal.sprite = silver;
        else if (score >= 1)
            medal.sprite = bronze;
        
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void pauseGame(bool pause)
    {
        
        if (pause)
        {
            Time.timeScale = 0f;
            bgMusic.Pause();
            pauseIcon.SetActive(true);
        }
        else 
        {
            Time.timeScale = 1f;
            bgMusic.Play();
            pauseIcon.SetActive(false);
        }

    }

    public void gameOver()
    {
        Time.timeScale = 0f;
        birdIsAlive = false;
        bgMusic.Stop();
        gameOverScreen.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOverScreen.activeSelf == true)
        {
            restartButton.onClick.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.P) && birdIsAlive)
        {
            pauseIcon.GetComponent<AudioSource>().Play();
            if (isPaused)
            {
                isPaused = false;
                pauseGame(false);
            }
            else
            {
                isPaused = true;
                pauseGame(true);
            }
        }
    }

}
