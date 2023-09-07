using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        gameObject.transform.Rotate(0f,0f,10f * Time.deltaTime * speed);
    }
}
