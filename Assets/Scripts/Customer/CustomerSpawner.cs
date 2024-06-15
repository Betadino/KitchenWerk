using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{

    public GameObject customer;


    void Start()
    {
        GameManager.E_orderDelivered += DeployCustomer;
    }

    void OnDestroy() {
         GameManager.E_orderDelivered -= DeployCustomer;
    }
    
    void DeployCustomer()
    {
        Instantiate(customer, gameObject.transform.position, Quaternion.identity);
    }

    
}