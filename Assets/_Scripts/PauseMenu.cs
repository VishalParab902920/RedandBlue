using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public static bool isGamePaused = false;
    public GameObject pauseUI;
    public GameObject rotator;
    RotatorManager rotatorScript;
    public GameObject GameOverUI;
    public Text scoreText;
    public static bool isGameOver = false;
    float speed;


    private void Start()
    {
        rotatorScript = rotator.GetComponent<RotatorManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        GameOver();
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = speed;
        isGamePaused = false;
        rotatorScript.enabled = true;
        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        speed = Time.timeScale;
        Time.timeScale = 0f;
        isGamePaused = true;
        rotatorScript.enabled = false;
        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        GameOverUI.SetActive(false);
        GameManager.speed = 1f;
        Time.timeScale = 1f;
        GameManager.score = 0;
        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Click");
    }
    public void Exit()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void GameOver()
    {
        if(isGameOver)
        {
            AdManager.adCount += 1;
            AdManager.canShowAd = true;
            scoreText.text = GameManager.score.ToString();
            GameOverUI.SetActive(true);
            isGameOver = false;
        }

    }
}

