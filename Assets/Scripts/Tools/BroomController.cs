using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    private GameObject player;
    private GameObject holdBroom;
    private GameObject trash;
    public static bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        holdBroom = GameObject.FindWithTag("HoldBroom");
        trash = GameObject.FindWithTag("Trash");
    }

    void Update()
    {
        if (isPickedUp)
        {
            // Adjusts the position and rotation of the broom relative to the player
            transform.position = holdBroom.transform.position;
            transform.rotation = player.transform.rotation;
        }

        if (isPickedUp && Input.GetKey(KeyCode.F))
        {
            transform.parent = null;

            isPickedUp = false;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player && Input.GetKey(KeyCode.E))
        {
            // Set the broom as a child of the player
            transform.SetParent(player.transform);

            isPickedUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == trash) // Clean the trash
        {
            Destroy(collision.gameObject);

            isPickedUp = true;
        }
    }
}