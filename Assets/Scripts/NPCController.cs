using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private GameObject player;
    public GameObject ratPrefab;

    public Transform targetLocation; // Food location

    public float spawnInterval = 10f; // Interval between spawns in seconds

    private List<GameObject> rats = new List<GameObject>(); // List to store instantiated rats

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        // Start spawning rats every n seconds
        // InvokeRepeating("SpawnRat", spawnInterval, spawnInterval);

        // Spawns the rat in n seconds
        Invoke("SpawnRat", spawnInterval);
    }

    private void Update()
    {
        MoveRat();
    }

    void SpawnRat()
    {
        // Instantiate the rat at the current position of this GameObject
        GameObject rat = Instantiate(ratPrefab, transform.position, Quaternion.identity);
        // Add the instantiated rat to the list
        rats.Add(rat);
    }
    
    void MoveRat()
    {
        foreach (GameObject rat in rats)
        {
            // If the player does not have the broom
            if (BroomController.isPickedUp == false)
            {
                rat.transform.position = Vector2.MoveTowards(rat.transform.position, targetLocation.position, 2 * Time.deltaTime); // Move towards the food
            }

            // If the player has the broom and is close to the rat
            else if (BroomController.isPickedUp == true && Vector2.Distance(rat.transform.position, player.transform.position) <= 0.8f)
            {
                rat.transform.position = Vector2.MoveTowards(rat.transform.position, transform.position, 2 * Time.deltaTime); // Move towards the hole
            }
        }
    }
}
