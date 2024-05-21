using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    public int orderID;

    public GameObject[] orders;
    public Transform[] pos;

    //public float firstSpawn = 10f;
    //public float spawnInterval = 20f;
    void Start()
    {
        //InvokeRepeating("SpawnOrder", firstSpawn, spawnInterval);
    }

    void SpawnOrder()
    {
        int randomOrder = Random.Range(0, orders.Length);
        int randomPosition = Random.Range(0, pos.Length);

        Instantiate(orders[randomOrder], pos[randomPosition].position, Quaternion.identity);
    }
}
