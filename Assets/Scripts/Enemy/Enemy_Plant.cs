using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plant : EnemyTree_Controller
{
    [SerializeField] protected Bullet_Controller bullet;
    public static int dir;

    private Animator anim;


    // Update is called once per frame
    void Update()
    {
        if (!Enemy_HeadCheck.headCheck)
        {
            facingDir();
            PlayerCheck();

            if (isPlayer && !Enemy_HeadCheck.headCheck)
            {
                if (tempCoolDown <= 0)
                {
                    Fire();
                    enemyBulletSound.Play();
                    tempCoolDown = firingCoolDown;
                }
                tempCoolDown -= Time.deltaTime;
            }
        }
    }

    private void Fire()
    {
        Instantiate(bullet,firingPoint.position, Quaternion.identity,null);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - distance, transform.position.y));
    }

    private void PlayerCheck()
    {
        isPlayer = Physics2D.Raycast(transform.position, -Vector2.right * dir, distance, Player);
    }

    private void facingDir()
    {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            dir = -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            dir = 1;
        }

        transform.localScale = scale;
    }
}
