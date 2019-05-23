using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Click");
        GameManager.speed = 1f;
        Time.timeScale = 1f;
        GameManager.score = 0;
    }

    public void Exit()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
