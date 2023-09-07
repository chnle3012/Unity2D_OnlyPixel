using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dirrection;
    private int bulletDir = Enemy_Plant.dir;

    private void Update()
    {
        transform.Translate(dirrection * Time.deltaTime * speed * bulletDir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform")) 
        {
            bulletDir = Enemy_Plant.dir;
            Destroy(gameObject);
        }
    }
}
