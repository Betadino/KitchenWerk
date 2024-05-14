using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject Customers;
    public float firstSpawn = 10f;
    public float spawnInterval = 20f;
    void Start()
    {
        InvokeRepeating("SpawnNPC", firstSpawn, spawnInterval);
    }

    void SpawnNPC()
    {
        Instantiate(Customers, gameObject.transform.position, Quaternion.identity);
    }
}
