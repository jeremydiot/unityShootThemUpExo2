using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject Bullet1;

    public Vector3 bulletOffset;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet1",0.5f,2f);
    }

    public void SpawnBullet1()
    {
        Instantiate(Bullet1, transform.position+bulletOffset, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
