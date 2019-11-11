using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;
    private AudioSource audioEngine;
    public AudioClip portalEnterSound;
    public bool isGreen;

    
    void Start()
    {
        audioEngine = GetComponent<AudioSource>();
        if (isGreen == false )
        {
            GameObject portal = GameObject.FindGameObjectWithTag("GreenPortal");
            if (portal)
                destination = portal.GetComponent<Transform>();
        } else
        {
            GameObject portal = GameObject.FindGameObjectWithTag("PurplePortal");
            if (portal)
                destination = portal.GetComponent<Transform>();
        }
    }

    IEnumerator PortalEnter()
    {
        audioEngine.clip = portalEnterSound;
        audioEngine.Play();
        yield return new WaitForSeconds(0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "IgnorePortal" || tag == "GreenPortal" || tag == "PurplePortal")
            return;
        if (Vector2.Distance(transform.position, collision.transform.position) > .1f)
        {
            if (destination)
            {
                StartCoroutine(PortalEnter());
                collision.transform.position = new Vector2(destination.position.x, destination.position.y);
            }
        }
    }
}
