using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order currentOrder;

    // This method is called to serve a dish to the customer
    public void Serve(FoodItem servedItem)
    {
        GameManager.OrderDelivered();
        if (currentOrder != null && servedItem.itemName == currentOrder.requiredRecipe.result.itemName)
        {
            Debug.Log("Customer is satisfied with the order: " + currentOrder.orderName);
            //Aqui adicionar reward ao jogador.
            GameManager.Instance.AddScore();
            // Handle customer satisfaction (e.g., increase score, remove customer, etc.)
        }
        else
        {
            //GameManager.Instance.RemoveHP();
            Debug.Log("Customer is not satisfied. Expected: " + currentOrder.requiredRecipe.result.itemName + ", but got: " + servedItem.itemName);
            // Handle customer dissatisfaction (e.g., reduce score, etc.)
        }
    }
}
