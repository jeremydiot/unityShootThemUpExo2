using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonus : MonoBehaviour
{
    public GameObject heart;
    public GameObject star;
    public float posMaxLeft;
    public float posMaxRight;
    public bool goLeft;
    public float speed;
    
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("SpawnBonus",2f,10f);
    }

    public void Level2()
    {
        CancelInvoke();
        InvokeRepeating("SpawnBonus2",2f,10f);
    }

    private void SpawnBonus()
    {

        int num = Random.Range(0, 4);
        if (num == 2)
        {
            Instantiate(heart, transform.position, transform.rotation);
        }

        if (num == 1 || num == 3)
        {
            Instantiate(star, transform.position, transform.rotation);
        }
    }
    
    private void SpawnBonus2()
    {

        //int num = Random.Range(0, 4);
        //if (num == 2)
        //{
            Instantiate(heart, transform.position, transform.rotation);
        //w}
    }
    
    private void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (transform.position.x >= posMaxRight)
        {
            goLeft = true;
        }
        else if (transform.position.x <= posMaxLeft)
        {
            goLeft = false;
        }
    }
}
