using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BumController : MonoBehaviour
{
    public static bool bumIsDestroyed = false;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If the player interacts with the bum, the bum is destroyed
        if (Input.GetKey(KeyCode.E))
        { 
            Destroy(gameObject);

            bumIsDestroyed = true;
        }
    }
}
