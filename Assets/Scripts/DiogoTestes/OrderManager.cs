using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Recipe> availableRecipes;
    public List<Customer> customers;

    private void Start()
    {
        GenerateRandomOrders();
    }

    public void GenerateRandomOrders()
    {
        foreach (Customer customer in customers)
        {
            Recipe randomRecipe = availableRecipes[Random.Range(0, availableRecipes.Count)];
            customer.currentOrder = new Order(randomRecipe.recipeName, randomRecipe);
            Debug.Log("Generated order for customer: " + customer.currentOrder.orderName);
        }
    }
}
