using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int healthPoint;
    private bool onceDestroy = false;
    public float destroyDelay = 0.5f;
    
    private void Update()
    {
        if (healthPoint <= 0 && !onceDestroy)
        {
            onceDestroy = true;
            GameplayManager.Instance.scoreValue += 100;
            Destroy(gameObject, destroyDelay);
                
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject, destroyDelay);
            GameplayManager.Instance.scoreValue -= 50;
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject, destroyDelay);
            healthPoint--;
        }
        
    }
}
