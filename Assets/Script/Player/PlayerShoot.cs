using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 bulletOffset;

    private float timer = 0;
    public float keybordDelay = 0.1f;

    private bool bossRotate = false;
    private GameObject GOBoss;

    private void Start()
    {
        GOBoss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ( timer >= keybordDelay )
        {
            // On spacebar press, send dog
            if ( Input.GetKeyDown ( KeyCode.Space ) )
            {
                Instantiate(bullet, transform.position + bulletOffset, transform.rotation);
                timer = 0;
            }
        }

        if (bossRotate)
        {
            GOBoss.transform.RotateAround(GOBoss.transform.position, new Vector3(0,0,1), 1000*Time.deltaTime);    
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NormalStar"))
        {
            bossRotate = true;
            Destroy(other.gameObject);
            GOBoss.GetComponent<BossShoot>().enabled = false;
            GOBoss.GetComponent<BossMovement>().enabled = false;
            Invoke("RestartBoss",5f);
        }
    }

    public void RestartBoss()
    {
        CancelInvoke("RestartBoss");
        bossRotate = false;
        GOBoss.GetComponent<BossShoot>().enabled = true;
        GOBoss.GetComponent<BossMovement>().enabled = true;
        GOBoss.transform.rotation = new Quaternion();
    }
}
    
