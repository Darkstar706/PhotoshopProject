using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkullCollect : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Skulls: " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plus")
        {
           score++;
           scoreText.text = "Skulls: " + score;
           Destroy(collision.gameObject);
            if (score > 10)
            {
             SceneManager.LoadScene("Win");
            }
        }
    }
}

