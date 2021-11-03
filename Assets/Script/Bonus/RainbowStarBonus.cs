using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowStarBonus : MonoBehaviour
{
    public float speed;
    private int yMin;

    public float timerDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timerDestroy);
        yMin = Random.Range(-4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yMin)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

    }
}
