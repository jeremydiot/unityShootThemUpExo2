using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletEnemy;
    public Vector3 bulletOffset;
    // Start is called before the first frame updatepublic Animator animator;
    void Start()
    {
        InvokeRepeating("SpawnBullet",1f,1.5f);
    }

    void SpawnBullet()
    {
        Instantiate(bulletEnemy, transform.position + bulletOffset, transform.rotation);
    }
}
