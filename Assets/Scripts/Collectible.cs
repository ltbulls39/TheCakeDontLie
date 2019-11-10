using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    float timeToCollect = 2f;
    bool canCollect = true;
    float collectTimer;



    private void Update()
    {
        if (!canCollect)
        {
            // Can't collect, reset timer
            collectTimer -= Time.deltaTime;
            if (collectTimer < 0)
                canCollect = true;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Recently collected, return
        if (!canCollect || collision.gameObject.tag != "Player")
            return;
        canCollect = false;
        collectTimer = timeToCollect;

        // Increase players health
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player.playerHealth < player.maxHealth)
        {
            player.playerHealth++;
            Destroy(gameObject);
        }
    }
}
