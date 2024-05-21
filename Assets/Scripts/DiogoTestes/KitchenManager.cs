using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    private Dictionary<int, Order> activeOrders = new Dictionary<int, Order>();

    public void StartCooking(Order order)
    {
        activeOrders[order.orderId] = order;
        // Logic to start cooking process
    }

    public void UpdateOrderStatus(int orderId, string status)
    {
        if (activeOrders.ContainsKey(orderId))
        {
            //activeOrders[orderId].status = status;
        }
    }

    // Additional methods to check ingredient availability, track time, etc.
}
