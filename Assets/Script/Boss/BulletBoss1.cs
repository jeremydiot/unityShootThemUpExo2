using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss1 : MonoBehaviour
{
    public bool follow = true;
    public Animator animator;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject GOPlayer = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 dir = GOPlayer.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector2.MoveTowards(transform.position, GOPlayer.transform.position, speed * Time.deltaTime);
        //transform.Translate(GOPlayer.transform.position * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("state",false);
            Destroy(gameObject,0.2f);
        }

        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
