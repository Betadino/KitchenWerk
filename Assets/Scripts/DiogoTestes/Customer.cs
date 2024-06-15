using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order currentOrder;

    // This method is called to serve a dish to the customer
    public void Serve(FoodItem servedItem)
    {
        if (currentOrder != null && servedItem.itemName == currentOrder.requiredRecipe.result.itemName)
        {
            Debug.Log("Customer is satisfied with the order: " + currentOrder.orderName);
            // Handle customer satisfaction (e.g., increase score, remove customer, etc.)
        }
        else
        {
            Debug.Log("Customer is not satisfied. Expected: " + currentOrder.requiredRecipe.result.itemName + ", but got: " + servedItem.itemName);
            // Handle customer dissatisfaction (e.g., reduce score, etc.)
        }
    }
}
