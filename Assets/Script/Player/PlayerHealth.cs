using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthPoint;

    private void Start()
    {
        GameplayManager.Instance.life.text = "Life : "+healthPoint.ToString();
    }   

    private void Update()
    {
        GameplayManager.Instance.life.text = "Life : "+healthPoint.ToString();
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
            GameplayManager.Instance.panelGameOver.SetActive(true);
            GameplayManager.Instance.newScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RainbowHeart"))
        {
            healthPoint += 5;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BulletEnemy"))
        {
            healthPoint--;
            GameplayManager.Instance.scoreValue -= 50;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            healthPoint--;
            GameplayManager.Instance.scoreValue -= 25;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BulletBoss1"))
        {
            healthPoint--;
            GameplayManager.Instance.scoreValue -= 50;
        }
        
    }
}
