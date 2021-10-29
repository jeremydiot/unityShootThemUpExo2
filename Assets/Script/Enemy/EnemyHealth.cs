using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int healthPoint;

    private void Update()
    {
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
            GameplayManager.Instance.scoreValue += 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameplayManager.Instance.scoreValue -= 50;
        }
        if (other.CompareTag("Bullet"))
        {
            healthPoint--;
            Destroy(other.gameObject);
        }
        
    }
}
