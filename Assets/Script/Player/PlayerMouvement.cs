using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float speed = 10;

    public Camera mainCamera;
    private Vector2 screenBounds;

    private float objectWidth;
    private float objectHeight;

    private void Start() {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, mainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    public void Update() {

        if (Input.GetKey("up")){
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (Input.GetKey("down")){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        } else if (Input.GetKey("left")){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }else if (Input.GetKey("right")){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth,screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight,screenBounds.y - objectHeight);
        transform.position = viewPos;

    }
}
