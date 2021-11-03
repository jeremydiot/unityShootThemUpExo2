using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 10;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -18.3)
        {
            Vector3 viewPos = transform.position;
            viewPos.x = 18.3f;
            transform.position = viewPos;
        }
    }
}
