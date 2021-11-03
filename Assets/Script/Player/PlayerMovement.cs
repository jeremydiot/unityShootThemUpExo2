using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RainbowStar"))
        {
            GameObject[] bulletsEnemy = GameObject.FindGameObjectsWithTag("BulletEnemy");
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < bulletsEnemy.Length; i++)
            {
                Destroy(bulletsEnemy[i]);
            }

            for (int i = 0; i < enemy.Length; i++)
            {
                if (i % 3 == 0)
                {
                    Destroy(enemy[i]);
                }
            }
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {

        float verticalMove = Input.GetAxisRaw("Vertical") * speed;
        float horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        float x = 0;
        float y = 0;
        
        Instantiate(raindow, transform.position, transform.rotation);
        
        animator.SetFloat("vertical_movment", verticalMove);
        
        if (Input.GetKey("up")) y = 1;
        if (Input.GetKey("down")) y = -1;
        if (Input.GetKey("left")) x = -1;
        if (Input.GetKey("right")) x = 1;
        
        if (Input.GetKey("up") && Input.GetKey("down")) y = 0;
        if (Input.GetKey("left") && Input.GetKey("right")) x = 0;
        
        transform.Translate(new Vector3(x,y) * speed * Time.deltaTime);
    }

    private void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth,screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight,screenBounds.y - objectHeight);
        transform.position = viewPos;

    }
}
