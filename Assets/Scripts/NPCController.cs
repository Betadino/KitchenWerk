using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject ratPrefab; // Assign your Rat prefab in the inspector
    public Transform targetLocation; // Assign the target location in the inspector
    public float spawnInterval = 10f; // Interval between spawns in seconds
    private GameObject player;

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
            if (rat != null) // Check if the rat is not destroyed
            {
                rat.transform.position = Vector2.MoveTowards(rat.transform.position, targetLocation.position, 3 * Time.deltaTime); // Move towards the food
            }

            else if (BroomController.isPickedUp == true && Vector2.Distance(rat.transform.position, player.transform.position) <= 1f) // If the player has the broom and is close to the rat
            {
                rat.transform.position = Vector2.MoveTowards(rat.transform.position, transform.position, 3 * Time.deltaTime); // Move towards the hole

                Debug.Log("oi");
            }
        }
    }
}
