using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;
    public bool isGreen;

    
    void Start()
    {
        if (isGreen == false )
        {
            destination = GameObject.FindGameObjectWithTag("GreenPortal").GetComponent<Transform>();
        } else
        {
            destination = GameObject.FindGameObjectWithTag("PurplePortal").GetComponent<Transform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Tilemap")
            return;
        if (Vector2.Distance(transform.position, collision.transform.position) > .3f)
            collision.transform.position = new Vector2(destination.position.x, destination.position.y);
    }
}
