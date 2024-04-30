using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class RatController : MonoBehaviour
{
    private GameObject player;
    public GameObject ratHole;

    public GameObject[] targets; // List to store targets

    public Vector3 selectedWaypoint;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        targets = GameObject.FindGameObjectsWithTag("pickable");

        selectedWaypoint = ChooseWaypoint();
    }

    private void Update()
    {
        MoveToTarget(selectedWaypoint);
    }

    void MoveToTarget(Vector3 waypoint)
    {
        // If the player does not have the broom and is away from the rat
        if (BroomController.isPickedUp == false || Vector2.Distance(gameObject.transform.position, player.transform.position) > 0.5f)
        {
            // Move the rat towards the selected target
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoint, 2 * Time.deltaTime);
        }

        // If the player has the broom and is close to the rat
        else if (BroomController.isPickedUp == true && Vector2.Distance(gameObject.transform.position, player.transform.position) <= 0.5f)
        {
            // Move the rat towards the hole
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, ratHole.transform.position, 2 * Time.deltaTime);

            if (gameObject.transform.position == ratHole.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    Vector3 ChooseWaypoint()
    {
        // Select a random target from the targets list
        int randomIndex = Random.Range(0, targets.Length);
        GameObject randomTarget = targets[randomIndex];

        return randomTarget.transform.position;
    }
}
