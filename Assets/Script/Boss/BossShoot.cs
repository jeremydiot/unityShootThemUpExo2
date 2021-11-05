using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject Bullet1;

    public Vector3 bulletOffset;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        InvokeRepeating("StartAnimation",0.5f,2f);
    }

    public void StartAnimation()
    {
        animator.SetInteger("state",1);
        Invoke("SpawnBullet",0.5f);
    }

    public void SpawnBullet()
    {
        
        Instantiate(Bullet1, transform.position+bulletOffset, transform.rotation);
        Invoke("StopAnimation",0.5f);
    }

    public void StopAnimation()
    {
        animator.SetInteger("state",0);
    }

    private void OnDisable()
    {
        animator.SetInteger("state",0);
        CancelInvoke();
    }
}
