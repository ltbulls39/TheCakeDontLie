using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    int enemyHealth = 1;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
            takeDamage();
    }

    private void takeDamage()
    {
        if (enemyHealth <= 1)
        {
            Debug.Log("Enemy killed!");
            Destroy(gameObject);
        }
        else
        {
            enemyHealth--;
            Debug.Log("Took damage, now have: " + enemyHealth);
        }
    }
}
