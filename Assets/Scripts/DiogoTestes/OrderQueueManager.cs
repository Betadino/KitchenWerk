using System.Collections.Generic;
using UnityEngine;

public class OrderQueueManager : MonoBehaviour
{
    private List<Order> orderQueue = new List<Order>();

    public void AddOrder(Order newOrder)
    {
        orderQueue.Add(newOrder);
    }

    public void CompleteOrder(int orderId)
    {
        foreach (var order in orderQueue)
        {
            if (order.orderId == orderId)
            {
                orderQueue.Remove(order);
                break;
            }
        }
    }

    // Additional methods to update UI, etc.
}
