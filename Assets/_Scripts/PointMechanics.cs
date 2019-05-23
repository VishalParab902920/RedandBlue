using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMechanics : MonoBehaviour {

    public float movementSpeed;
    Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((this.gameObject.tag == "RedPoint") && (collision.gameObject.tag == "RedPlayer"))
        {
            GameManager.score += 1f  ;
            FindObjectOfType<AudioManager>().Play("PointScored");
            anim.SetTrigger("Shrink");
            Destroy(this.gameObject,0.2f);           
        }
        if ((this.gameObject.tag == "BluePoint") && (collision.gameObject.tag == "BluePlayer"))
        {
            GameManager.score += 1f;
            FindObjectOfType<AudioManager>().Play("PointScored");
            anim.SetTrigger("Shrink");
            Destroy(this.gameObject,0.2f);
        }

        if ((this.gameObject.tag == "RedPoint") && (collision.gameObject.tag == "BluePlayer"))
        {
            FindObjectOfType<AudioManager>().Play("Out");
            Time.timeScale = 0.0f;
            PauseMenu.isGameOver = true;

        }
        if ((this.gameObject.tag == "BluePoint") && (collision.gameObject.tag == "RedPlayer"))
        {
            FindObjectOfType<AudioManager>().Play("Out");
            Time.timeScale = 0.0f;
            PauseMenu.isGameOver = true;
        }


    }

    public void MovePoint()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, movementSpeed * Time.deltaTime);
    }
}
