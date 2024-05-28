using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BumController : MonoBehaviour
{
    public static bool bumIsDestroyed = false;
    public float timer = 20f;
    public GameObject trashPrefab;

    private void Start()
    {

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) // If the player doesn't deal with the bum in time, the bum will throw trash
        {
            Instantiate(trashPrefab,
                        Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), /* Random Width */
                                                                   UnityEngine.Random.Range(0, Screen.height), /* Random Height */
                                                                   Camera.main.nearClipPlane /* Nearest point of the camera view */)),
                        Quaternion.identity);

            timer = 20f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If the player interacts with the bum, the bum goes away
        if (Input.GetKey(KeyCode.E))
        { 
            Destroy(gameObject);

            bumIsDestroyed = true;
        }

    }
}