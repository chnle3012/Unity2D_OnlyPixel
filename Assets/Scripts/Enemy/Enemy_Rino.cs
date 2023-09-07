using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rino : MonoBehaviour
{
    Animator anim;
    [SerializeField] private LayerMask Player;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;

    private float distance;
    private bool flip;
    private bool isPlayer;
    private int dir;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Enemy_HeadCheck.headCheck)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Run", false);

            distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance <= attackDistance)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                Flip();
            }
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
            dir = 1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            dir = -1;
        }

        transform.localScale = scale;
    }

}
