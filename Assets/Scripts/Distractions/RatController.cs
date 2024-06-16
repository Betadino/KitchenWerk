using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatController : MonoBehaviour
{
    private GameObject player;
    private GameObject ratHole;

    public float destroyTimer = 5f;
    private bool targetIsDestroyed = false;

    public GameObject[] targets; // List to store targets

    public Vector3 selectedWaypoint; // Position of target

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        ratHole = GameObject.FindWithTag("RatHole");
        targets = GameObject.FindGameObjectsWithTag("pickable");

        selectedWaypoint = ChooseWaypoint();
        if (selectedWaypoint == Vector3.zero) // If there isn't any pickable, the rat is destroyed
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        MoveToTarget(selectedWaypoint);
    }

    void MoveToTarget(Vector3 waypoint)
    {
        // If the player does not have the broom, is away from the rat and the target has not been destroyed
        if (BroomController.isPickedUp == false && Vector2.Distance(gameObject.transform.position, player.transform.position) < 0.1f && !targetIsDestroyed)
        {
            // Move the rat towards the selected target
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoint, 2 * Time.deltaTime);
        }
        else
        {
            // Move the rat towards the hole
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, ratHole.transform.position, 2 * Time.deltaTime);

            if (gameObject.transform.position == ratHole.transform.position)
            {
                Destroy(gameObject); // The rat is destroyed if it is in the rat hole
            }
        }

        /*
        // If the player has the broom and is close to the rat
        else if (BroomController.isPickedUp == true && Vector2.Distance(gameObject.transform.position, player.transform.position) < 0.01f)
        {
            // Move the rat towards the hole
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, ratHole.transform.position, 2 * Time.deltaTime);
            Debug.Log("Rat to Hole");
            if (gameObject.transform.position == ratHole.transform.position)
            {
                Destroy(gameObject); // The rat is destroyed if it is in the rat hole
            }
        }
        // If the target is destroyed then the rat will move towards the rat hole
        else if (targetIsDestroyed)
        {
            Debug.Log("Rat destroyed Target");
            // Move the rat towards the hole
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, ratHole.transform.position, 2 * Time.deltaTime);
            if (gameObject.transform.position == ratHole.transform.position)
            {
                Destroy(gameObject); // The rat is destroyed if it is in the rat hole
            }
        }
        */
    }

    Vector3 ChooseWaypoint()
    {
        if (targets.Length == 0) // If there isn't any pickable
        {
            return Vector3.zero;
        }
        else
        {
            // Select a random target from the targets list
            int randomIndex = UnityEngine.Random.Range(0, targets.Length);
            GameObject randomTarget = targets[randomIndex];

            return randomTarget.transform.position;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pickable")
        {
            // If the rat is in the target and n seconds have passed, then it will destroy the target
            destroyTimer -= Time.deltaTime;
            if (destroyTimer < 0f)
            {
                Destroy(collision.gameObject);
                targetIsDestroyed = true;
                destroyTimer = 0f;
            }
        }
    }
}