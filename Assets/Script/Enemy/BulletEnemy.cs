using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 20;
    public float timerDestroy = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timerDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
