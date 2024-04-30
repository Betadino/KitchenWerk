using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    private GameObject player;
    private GameObject holdBroom;
    public static bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        holdBroom = GameObject.FindWithTag("HoldBroom");
    }

    void Update()
    {
        if (isPickedUp)
        {
            // Adjusts the position and rotation of the broom relative to the player
            transform.position = holdBroom.transform.position;
            transform.rotation = player.transform.rotation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            // Set the broom as a child of the player
            transform.SetParent(player.transform);

            isPickedUp = true;
        }
    }
}
