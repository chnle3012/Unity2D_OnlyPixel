using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTree_Controller : MonoBehaviour
{
    [SerializeField] protected Transform firingPoint;
    [SerializeField] protected float firingCoolDown;

    [SerializeField] protected float distance;
    [SerializeField] protected LayerMask Player;
    [SerializeField] protected GameObject player;
    [SerializeField] protected AudioSource enemyBulletSound;

    protected float tempCoolDown;
    protected bool isPlayer;
}
