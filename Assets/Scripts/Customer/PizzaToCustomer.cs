using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PizzaToCustomer : MonoBehaviour
{
    
    public Customer currentCustomer;

    private void Start() {

    }
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.gameObject.CompareTag("Customer"))
        {
              
            currentCustomer.Serve(gameObject.GetComponent<FoodItem>());
           
            
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {

        if(other.gameObject.CompareTag("Customer"))
        {
              
            Destroy(this.gameObject);
           
            
        }
    }
    

}
