using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int healthPoint;
    private bool onceDestroy = false;
    public float destroyDelay = 0.5f;
    public Animator animator;
    private bool once = false;
    private void Update()
    {
        if (healthPoint <= 0 && !onceDestroy)
        {
            onceDestroy = true;
            GameplayManager.Instance.scoreValue += 100;
            Destroy(gameObject, destroyDelay);
                
        }
        
        if (healthPoint <= 25 && !once)
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
            healthPoint--;
        }
        
    }

    private void stage2()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShoot>().RestartBoss();
        gameObject.GetComponent<BossShoot>().enabled = false;
        gameObject.GetComponent<BossMovement>().enabled = false;
        animator.SetInteger("state",2);
        
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
        
        Invoke("stage2movement",2);
    }

    private void stage2movement()
    {
        gameObject.GetComponent<BossMovement2>().enabled = true;
    }
}
