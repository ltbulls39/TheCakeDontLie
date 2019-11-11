using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public LayerMask toHit; // Tells us what we WANT to hit

    private Transform firePoint;
    public GameObject greenPortalPrefab;
    public GameObject purplePortalPrefab;
    GameObject greenInstantiated;
    GameObject purpInstantiated;

    private bool isGreenActive = false;
    private bool isPurpActive = false;

    private AudioSource audioPlayer;
    public AudioClip portalSound;
    

    // Start is called before the first frame update
    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();

        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firepoint found???");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            greenInstantiated = shoot(greenPortalPrefab, greenInstantiated);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            purpInstantiated = shoot(purplePortalPrefab, purpInstantiated);
        }
        else if (Input.GetButtonDown("Reset"))
            resetPortals();
    }

    IEnumerator PlayPortal()
    {
        audioPlayer.clip = portalSound;
        audioPlayer.Play();
        yield return new WaitForSeconds(0f);
    }

    private GameObject shoot(GameObject portalPrefab, GameObject instance)
    {
        // Default behavior: Sound any time a portal is shot, even if it doesn't connect
        StartCoroutine(PlayPortal());

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, toHit);

        if (hit.collider != null)
        {
            if (hit.collider.name == "Tilemap")
            {
                if (Vector3.Angle(Vector3.down, hit.normal) == 135)
                    return instance;
                // Hit a valid tile, spawn a portal
                Vector3 spawnLocation = new Vector3(mousePosition.x, mousePosition.y);

                // Rotate vector a little so it spawns correctly on platform
                Vector2 vector = hit.normal;
                vector = Quaternion.Euler(-90, -90, 0) * vector;


                Quaternion rot = Quaternion.FromToRotation(Vector3.up, vector);
                if (instance != null)
                {
                    // Animates end sequence, then destroys portal
                    Animator anim = instance.GetComponent<Animator>();
                    anim.SetBool("ToDestroy", true);
                    Destroy(instance, instance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                }
                // Creates new portal
                instance = (GameObject)Instantiate(portalPrefab, hit.point, rot);
                return instance;
            }
        }
        return instance;
    }


    private void resetPortals()
    {
        // Resets both portals
        if (greenInstantiated != null)
        {
            greenInstantiated.GetComponent<Animator>().SetBool("ToDestroy", true);
            Destroy(greenInstantiated, greenInstantiated.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        if (purpInstantiated != null)
        {
            purpInstantiated.GetComponent<Animator>().SetBool("ToDestroy", true);
            Destroy(purpInstantiated, purpInstantiated.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
