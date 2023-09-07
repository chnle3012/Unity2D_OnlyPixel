using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Footcheck : MonoBehaviour
{
    [SerializeField] private AudioSource enemyDeathSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_head"))
        {
            enemyDeathSound.Play();
        }
    }

}
