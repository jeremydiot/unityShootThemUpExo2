using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int healthPoint;
    private bool onceDestroy = false;
    public float destroyDelay = 0.5f;
    private bool once = false;
    private void Update()
    {
        
        if (healthPoint <= 0 && !onceDestroy)
        {
            onceDestroy = true;
            GameplayManager.Instance.scoreValue += 100;
            Destroy(gameObject, destroyDelay);
            GameplayManager.Instance.finish();
                
        }
        
        if (healthPoint <= 20 && !once)
        { 
            once = true;
            Invoke("stage2",0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject, destroyDelay);
            GameplayManager.Instance.scoreValue += 25;
            healthPoint--;
        }
        
    }

    private void stage2()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().RestartBoss();
        gameObject.GetComponent<BossShoot>().enabled = false;
        gameObject.GetComponent<BossMovement>().enabled = false;

        GameObject GOspawner = GameObject.FindGameObjectWithTag("SpawnerBonus");
        GOspawner.GetComponent<SpawnerBonus>().Level2();
        
        GameObject[] GOstar = GameObject.FindGameObjectsWithTag("NormalStar");
        GameObject[] GObullet = GameObject.FindGameObjectsWithTag("BulletBoss1");
        
        for (int i = 0; i < GOstar.Length; i++)
        {
            Destroy(GOstar[i]);
        }
        
        for (int i = 0; i < GObullet.Length; i++)
        {
            Destroy(GObullet[i]);
        }
        
        gameObject.GetComponent<BossMovement2>().enabled = true;
        gameObject.GetComponent<BossShoot2>().enabled = true;
    }
    
}
