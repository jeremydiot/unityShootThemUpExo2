using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossMovement : MonoBehaviour
{
    public float speed = 10;

    public Camera mainCamera;
    private Vector2 screenBounds;

    public Animator animator;
    public GameObject raindow;

    private float objectWidth;
    private float objectHeight;

    private void Start() {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        InvokeRepeating("SpawnBoss", 0f, 2f);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad0))
        {
            animator.SetInteger("state",0);
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            animator.SetInteger("state",1);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            animator.SetInteger("state",2);
        }   //transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SpawnBoss()
    {
        float xmin, xmax, ymin, ymax;
        xmin = (screenBounds.x * -1)+objectWidth+6;
        xmax = (screenBounds.x)-objectWidth;

        ymin = (screenBounds.y * -1)+objectHeight;
        ymax = (screenBounds.y)-objectHeight;

        Vector3[] bossPos = new Vector3[5];

        bossPos[0] = new Vector3((xmax + xmin)/2, (ymax + ymin)/2, 0);
        bossPos[1] = new Vector3(xmax/2, ymax/2, 0);
        bossPos[2] = new Vector3(xmin/2, ymin/2, 0);
        bossPos[3] = new Vector3(xmin/2, ymax/2, 0);
        bossPos[4] = new Vector3(xmax/2, ymin/2, 0);

        transform.position = bossPos[Random.Range(0, 5)];
    }
    
}
