using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMouvement : MonoBehaviour
{
    public float posMax;
    public bool goUp;
    public float speed;
    public GameObject enemySpawn;

    private void Start() {
        InvokeRepeating("SpawnEnemy",1f,1f);
    }

    void SpawnEnemy()
    {
        Instantiate(enemySpawn, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (goUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (transform.position.y >= posMax)
        {
            goUp = false;
        }
        else if (transform.position.y <= -posMax)
        {
            goUp = true;
        }
    }
}
