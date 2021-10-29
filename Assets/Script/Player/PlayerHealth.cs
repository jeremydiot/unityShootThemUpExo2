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
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
            GameplayManager.Instance.panelGameOver.SetActive(true);
            GameplayManager.Instance.newScore();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            healthPoint--;
            GameplayManager.Instance.life.text = "Life : "+healthPoint.ToString();
            GameplayManager.Instance.scoreValue -= 25;
            Destroy(other.gameObject);
        }
        
    }
}
