using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Trunk : EnemyTree_Controller
{
    [SerializeField] protected BulletTrunk_Controller bullet;
    public static int Trunkdir;

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
        Instantiate(bullet, firingPoint.position, Quaternion.identity, null);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x - distance, transform.position.y));
    }

    private void PlayerCheck()
    {
        isPlayer = Physics2D.Raycast(transform.position, -Vector2.right * Trunkdir, distance, Player);
    }

    private void facingDir()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            Trunkdir = -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            Trunkdir = 1;
        }

        transform.localScale = scale;
    }
}
