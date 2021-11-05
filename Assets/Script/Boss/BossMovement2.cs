using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossMovement2 : MonoBehaviour
{
    public float speed = 10;

    public Camera mainCamera;
    private Vector2 screenBounds;

    public Animator animator;

    private float objectWidth;
    private float objectHeight;
    private float xmin, xmax, ymin, ymax;
    private void Start() {
        
    }

    private void Awake()
    {
        this.enabled = false;
    }

    private void OnEnable()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        
        
        xmin = (screenBounds.x * -1)+objectWidth+8;
        xmax = (screenBounds.x)-objectWidth;

        ymin = (screenBounds.y * -1)+objectHeight;
        ymax = (screenBounds.y)-objectHeight;
        
        transform.position  = new Vector3(xmin, (ymax+ymin)/2, 0);
    }

    private void Update()
    {
        Vector3 position  = new Vector3((xmax + xmin)/2, (ymax + ymin)/2, 0);
        
        Quaternion q = transform.rotation;
        transform.RotateAround(position, Vector3.forward, 100*Time.deltaTime);
        transform.rotation = q;
        
        //transform.RotateAround(gameObject.transform.position, Vector3.up, 30 * Time.deltaTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
