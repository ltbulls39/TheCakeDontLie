using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MW_Singleton : MonoBehaviour
{
    private static MW_Singleton instance = null;

    public static MW_Singleton Instance
    {
        get { return instance; }
    }

    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}

