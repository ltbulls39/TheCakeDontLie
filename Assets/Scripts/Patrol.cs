using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    float distance = 1f;
    private bool movingRight = true;
    public Transform groundDetect;


    void Update()
    {
        // Moves the character and then gets info on the ground beneath it
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, distance);
        Debug.DrawRay(groundDetect.position, Vector2.down, Color.red);


        if (groundInfo.collider == false)
        {
            // Collider not hittin anything
            if (movingRight == true)
            {
                // Turning left
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                // Turning right
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
