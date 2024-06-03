using UnityEngine;

[System.Serializable]
public class Order
{
    public string orderName;
    public Recipe requiredRecipe;

    public Order(string name, Recipe recipe)
    {
        orderName = name;
        requiredRecipe = recipe;
    }
}
