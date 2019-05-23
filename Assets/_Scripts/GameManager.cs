using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float speedUpTime;
    public float speedUpRate;
    private float startTime;
    public float speedLimit;
    public static float speed = 1f;
   
    public static float score = 0;
    public static float highScore;
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
        startTime = Time.time;
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    private void Update()
    {
        SpeedUp();
        scoreText.text = score.ToString();
        if(score>PlayerPrefs.GetFloat("HighScore",0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void SpeedUp()
    {
        float timer = Time.time - startTime;
        if(timer> speedUpTime)
        {
            if(speed<= speedLimit)
            {
                speed = speed + speedUpRate;
                Time.timeScale = speed;
                startTime = Time.time;
            }
            
        }
    }
}
