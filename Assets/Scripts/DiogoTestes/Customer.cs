using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order currentOrder;

    // This method is called to serve a dish to the customer
    public void Serve(FoodItem servedItem)
    {
        GameManager.OrderDelivered();
        if (GameManager.Instance.currentOrder != null && servedItem.itemName == GameManager.Instance.currentOrder.requiredRecipe.result.itemName)
        {
            Debug.Log("Customer is satisfied with the order: " + GameManager.Instance.currentOrder.orderName);
            GameManager.Instance.GainMoney();
            GameManager.Instance.GainScore();
            GameManager.Instance.ordersCompleted += 1;
            // Handle customer satisfaction (e.g., increase score, remove customer, etc.)
        }
        else
        {
            //GameManager.Instance.RemoveHP();
            Debug.Log("Customer is not satisfied. Expected: " + GameManager.Instance.currentOrder.requiredRecipe.result.itemName + ", but got: " + servedItem.itemName);
            GameManager.Instance.RemoveHP();
            // Handle customer dissatisfaction (e.g., reduce score, etc.)
        }
    }
}
