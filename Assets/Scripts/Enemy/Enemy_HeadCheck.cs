using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HeadCheck : MonoBehaviour
{
    private Animator anim;
    private Collider2D cld;
    private Rigidbody2D rb;
    public static bool headCheck = false;
    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        cld = transform.parent.GetComponent<Collider2D>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Dead", true);
            cld.enabled = false;
            headCheck = true;
            Invoke("DestroyEnemy", 1f);
        }
    }

    private void DestroyEnemy()
    {
        headCheck = false;
        Destroy(transform.parent.gameObject);   
    }
}
