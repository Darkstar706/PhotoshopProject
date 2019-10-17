using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MadCoinCollect : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "Pumpkins: " + score;
        //string foo = "" + score + "= Pumpkins: ";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Minus")
        {
            score--;
            Destroy(collision.gameObject);
            if(score < -10)
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().name);
            }
        }
        else if(collision.gameObject.tag == "Plus")
        {
            score++;
            scoreText.text = "Pumpkins: " + score;
            Destroy(collision.gameObject);
            if(score > 10)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
