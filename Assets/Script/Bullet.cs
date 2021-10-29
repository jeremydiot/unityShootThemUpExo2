using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20;
    public float timerDestroy = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timerDestroy);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
