using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomController : MonoBehaviour
{
    private GameObject player;
    public static bool isPickedUp = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isPickedUp)
        {
            // Adjust the position of the broom relative to the player if necessary
            transform.position = player.transform.position + new Vector3(0.15f, 0, 0);
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
