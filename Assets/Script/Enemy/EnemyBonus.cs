using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBonus : MonoBehaviour
{
    public GameObject heart;
    public GameObject star;

    public bool once = false;
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("SpawnBonus",2f,1f);
    }

    private void SpawnBonus()
    {
        if(once) return;
        int num = Random.Range(0, 50);
        if (num == 25)
        {
            Instantiate(heart, transform.position, transform.rotation);
            once = true;
        }

        if (num == 1 || num == 50)
        {
            once = true;
            Instantiate(star, transform.position, transform.rotation);
        }
    }
}
