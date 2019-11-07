using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    float distance = 1f;

    private bool movingRight = true;

    public Transform groundDetect;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, distance);
        Debug.DrawRay(groundDetect.position, Vector2.down, Color.red);
        if (groundInfo.collider == false)
        {
            Debug.Log("Ray hasn't collided with anything");
            if (movingRight == true)
            {
                Debug.Log("Turning left");
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                Debug.Log("Turning right");
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void FixedUpdate()
    {
        
    }
}
