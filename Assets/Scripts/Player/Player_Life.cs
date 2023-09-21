using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private int health = 3;
    [SerializeField] private int numberOfBlink;
    [SerializeField] private float blinkDuration;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private AudioSource deathSoundEfect;

    Enemy_Mushroom enemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            deathSoundEfect.Play();

            health--;
            hearts[health].SetActive(false);

            if (health >= 1)
            {
                StartCoroutine(Hurt());
            }
            else
            {
                Physics2D.IgnoreLayerCollision(7, 9, false);
                Physics2D.IgnoreLayerCollision(7, 8, false);
                Die();
            }
        }

        if(collision.gameObject.CompareTag("Heart"))
        {
            hearts[health].SetActive(true);
            health++;
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Dead");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        health = 3;
    }

    IEnumerator Hurt()
    {
        Physics2D.IgnoreLayerCollision(7,9, true);
        Physics2D.IgnoreLayerCollision(7,8, true);

        for (int i = 0; i < numberOfBlink; i++)
        {
            sr.color = new Color(255, 0, 0, 211);
            yield return new WaitForSeconds(blinkDuration);
            sr.color = new Color(255, 255, 255);
            yield return new WaitForSeconds(blinkDuration);
        }
        Physics2D.IgnoreLayerCollision(7, 9,false);
        Physics2D.IgnoreLayerCollision(7, 8,false);
    }
}
