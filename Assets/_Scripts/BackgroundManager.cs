using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {


    SpriteRenderer bg;
    public Sprite sprite1;
    public Sprite sprite2;
    public float changeTime;

    private float startTime;
    private void Start()
    {
        bg = GetComponent<SpriteRenderer>();
        bg.sprite = sprite1;
        startTime = Time.time;

    }
    private void Update()
    {
        ChangeBG();
    }

    public void ChangeBG()
    {
        float timer = Time.time - startTime;
        if (timer>changeTime)
        {
            if (bg.sprite == sprite1)
            {
                bg.sprite = sprite2;
                startTime = Time.time;
            }
            else if(bg.sprite==sprite2)
            {
                bg.sprite = sprite1;
                startTime = Time.time;
            }

        }
    }
}
