using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public int orderId;
    public List<string> ingredientsRequired;  //pepperoni, mushroom, bacon
    public List<string> preparationSteps;
    public float timeLimit;
    public int rewardPoints;

    // Additional methods to check if order is complete, etc.
}
