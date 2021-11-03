using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 bulletOffset;

    private float timer = 0;
    public float keybordDelay = 0.1f;
    
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
    }
}
