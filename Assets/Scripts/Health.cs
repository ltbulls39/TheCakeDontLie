using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int health;
    public int numHearts;

    public GameObject[] theHearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    GameObject heartPanel;

    private void Awake()
    {
        heartPanel = GameObject.Find("Hearts"); 
    }



    private void Update()
    {
        health = (int) GetComponent<PlayerController>().playerHealth;
        for (int i = 0; i < theHearts.Length; i++)
        {
            Debug.Log("Health: " + health);
            if (i < health)
            {
                theHearts[i].GetComponent<SpriteRenderer>().sprite = fullHeart;
            }
            else
            {
                theHearts[i].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            }

            if (i < numHearts)
                theHearts[i].SetActive(true);
            else
                theHearts[i].SetActive(false);
            
        }
    }
}
