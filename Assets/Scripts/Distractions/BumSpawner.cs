using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BumSpawner : MonoBehaviour
{
    public GameObject bum;

    public float spawnInterval = 20f; // Interval between spawns in seconds

    void Start()
    {
        // Spawns the bum after n seconds
        Invoke("SpawnBum", spawnInterval);
    }

    private void Update()
    {
        // Allows the bum to spawn again after he has been destroyed
        if (BumController.bumIsDestroyed == true)
        {
            Invoke("SpawnBum", spawnInterval);
            BumController.bumIsDestroyed = false;
        }
    }

    private void SpawnBum()
    {
        // Instantiate the bum at the current position of this GameObject
        Instantiate(bum, gameObject.transform.position, Quaternion.identity);
    }
}