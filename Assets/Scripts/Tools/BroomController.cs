using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BroomController : MonoBehaviour
{
    private GameObject player;
    private GameObject broom;
    public static bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        broom = GameObject.FindWithTag("HoldBroom"); // Empty object inside player for the broom position
    }

    void Update()
    {
        if (isPickedUp)
        {
            // Adjusts the position and rotation of the broom relative to the player
            transform.position = broom.transform.position;
            transform.rotation = player.transform.rotation;
        }

        if (isPickedUp && Input.GetKey(KeyCode.F)) // Drops the broom
        {
            transform.parent = null;

            isPickedUp = false;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player && Input.GetKey(KeyCode.E)) // Picks up the broom
        {
            // Set the broom as a child of the player
            transform.SetParent(player.transform);

            isPickedUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash") // Clean the trash
        {
            Destroy(collision.gameObject);
        }
    }
}