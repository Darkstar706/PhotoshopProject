using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    public GameObject prefab;
    public float bulletSpeed = 3.0f;
    public float bulletLifeTime = 1.5f;
    public float shootDelay = 5.0f;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //player.position.x;
        //player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shootDelay)
        {
            timer = 0;
            GameObject enemybullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Vector2 shootDir = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            shootDir.Normalize();
            enemybullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(enemybullet, bulletLifeTime);
        }
    }
}
