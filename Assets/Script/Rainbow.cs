using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public float speed = 10;
    public float timerDestroy = 1f;
    void Start()
    {
        Destroy(gameObject,timerDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
