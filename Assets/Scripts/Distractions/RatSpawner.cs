using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject rat;

    public float spawnInterval = 30f; // Interval between spawns in seconds

    void Start()
    {
        // Spawns rats every n seconds
        InvokeRepeating("SpawnRat", spawnInterval, spawnInterval);
    }
    
    void SpawnRat()
    {
        // Instantiate the rat at the current position of this GameObject
        Instantiate(rat, gameObject.transform.position, Quaternion.identity);
    }
}