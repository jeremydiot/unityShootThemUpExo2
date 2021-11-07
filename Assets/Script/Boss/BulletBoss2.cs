using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss2 : MonoBehaviour
{
    public float speed;
    

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Bullet"))
        {
            GameplayManager.Instance.scoreValue += 25;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }    
    }
    
    
}
