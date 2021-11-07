using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRick : MonoBehaviour
{
    public float posMax;
    public bool goUp;
    public float speed;
    public GameObject[] rick;
    public GameObject rickSpeek;
    private void Start() {
        InvokeRepeating("SpawnRick",1f,1f);
        InvokeRepeating("SpawnSpeek",18,25f);
    }

    public void SpawnSpeek()
    {
        GameObject GoRick = Instantiate(rickSpeek, Vector3.zero, Quaternion.identity);
        Destroy(GoRick, 10f);
    }

    void SpawnRick()
    {
        int num = Random.Range(0, rick.Length);
        Instantiate(rick[num], transform.position, Quaternion.identity);
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
