using System.Collections.Generic;
using UnityEngine;

// Recipes define which ingredients are needed to create a specific food item.
[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    // The name of the recipe (e.g., "PepperoniPizza", "MushroomPizza").
    public string recipeName;

    // The list of ingredients required for this recipe.
    public List<FoodItem> ingredients;

    // The resulting food item when the recipe is completed.
    public FoodItem result;
}
