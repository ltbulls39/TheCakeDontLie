using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
            Debug.Log("You win!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Win trigger entered");
        Debug.Log("Tag: " + collision.gameObject.tag);
        Debug.Log("Name: " + collision.gameObject.name);
        
        if (collision.gameObject.tag == "Cake")
        {
            Debug.Log("GameObject tag is CAKE!");
            SceneManager.LoadScene(2);
        }
    }
}
