using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossShoot2 : MonoBehaviour
{

    public GameObject bullet;
    public Vector3 bulletOffset;
    public Animator animator;
    private void Awake()
    {
        this.enabled = false;
    }

    private void OnEnable()
    {
        InvokeRepeating("StartAnimation",1f,5f);
    }

    private void StartAnimation()
    {
        animator.SetInteger("state",2);
        Invoke("SpawnBullet",1.5f);
    }
    
    private void SpawnBullet()
    {
        Instantiate(bullet, transform.position+bulletOffset, transform.rotation);
        
        Invoke("StopAnimation", 0.5f);
    }

    private void StopAnimation()
    {
        animator.SetInteger("state",0);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
