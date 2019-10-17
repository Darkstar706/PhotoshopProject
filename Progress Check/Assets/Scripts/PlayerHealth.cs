using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public Text healthText;
    public Slider healthSlider;
    public int Lives = 10;
    void Start()
    {
        healthText.text = "Hp: " + health;
        healthSlider.maxValue = health;
        healthSlider.value = health;
        //PlayerPrefs.SetInt("Lives", Lives);
        Lives = PlayerPrefs.GetInt("Lives");
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            healthText.text = "Hp: " + health;
            healthSlider.value = health;
            if(health < 1)
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene("Lose");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            health--;
            healthText.text = "Hp: " + health;
            healthSlider.value = health;
            if (health < 1)
            {
                if (Lives > 0)
                {


                    SceneManager.LoadScene(
                        SceneManager.GetActiveScene().name);
                    //SceneManager.LoadScene("Lose");
                    PlayerPrefs.SetInt("Lives", Lives - 1);
                }
                else
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    }
}
