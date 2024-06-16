using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class SpawnCustomer : MonoBehaviour
{
    public Transform  orderPoint, leavePoint;
    public GameObject customer;
    public static event Action<GameObject> E_ReceiveCustomer;

    
    void Start()
    {
        GameManager.E_orderDelivered += DeployCustomer;
        var cb = customer.GetComponent<CustomerBehaviour>();
        cb.orderPoint = orderPoint;
        cb.leavePoint = leavePoint;
        DeployCustomer();
    }

    void OnDestroy() {
         GameManager.E_orderDelivered -= DeployCustomer;
    }
    
    void DeployCustomer()
    {
        Instantiate(customer, gameObject.transform.position, Quaternion.identity);
        E_ReceiveCustomer?.Invoke(customer);
    }
}