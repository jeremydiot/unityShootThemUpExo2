using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCloud : MonoBehaviour
{
    public GameObject[] clouds;

    public float posMax;
    public bool goUp;
    public float speed;
    private void Start() {
        InvokeRepeating("SpawnCloud",1f,1f);
    }

    void SpawnCloud()
    {
        int range = Random.Range(0, clouds.Length);
        Instantiate(clouds[range], transform.position, Quaternion.identity);
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
