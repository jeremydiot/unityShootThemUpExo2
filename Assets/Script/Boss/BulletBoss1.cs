using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss1 : MonoBehaviour
{
    public bool follow = true;
    public Animator animator;
    public float speed;
    GameObject GOPlayer;
    void Start()
    {
        GOPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        try
        {
            Vector3 dir = GOPlayer.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.position = Vector2.MoveTowards(transform.position, GOPlayer.transform.position, speed * Time.deltaTime);

        }
        catch (Exception e)
        {
            Destroy(gameObject);
        }
     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("state",false);
            Destroy(gameObject,0.2f);
        }

        if (other.CompareTag("Bullet"))
        {
            GameplayManager.Instance.scoreValue += 25;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
