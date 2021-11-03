using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletEnemy;
    public Vector3 bulletOffset;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet",1f,1.75f);
    }

    void SpawnBullet()
    {
        Instantiate(bulletEnemy, transform.position + bulletOffset, transform.rotation);
    }
}
