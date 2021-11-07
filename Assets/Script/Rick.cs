using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rick : MonoBehaviour
{
    
    public float speed;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.left * speed * Time.deltaTime);
        transform.RotateAround(transform.position+Vector3.down*speed, new Vector3(0,0,1), angle*Time.deltaTime);
        
    }
}
