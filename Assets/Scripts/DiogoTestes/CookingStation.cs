using System.Collections.Generic;
using UnityEngine;

public class CookingStation : MonoBehaviour
{
    public Customer currentCustomer;

    // A list to keep track of the current ingredients at the cooking station.
    public List<FoodItem> currentIngredients = new List<FoodItem>();

    // The list of recipes available in the game.
    public List<Recipe> recipeList;

    // When a food item enters the cooking station's trigger collider,
    // it gets added to the current ingredients list.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player"))
        {
            // Check if the collided object has the FoodItem component.
            FoodItem foodItem = collision.gameObject.GetComponent<FoodItem>();
            if (foodItem != null)
            {
                // Add the food item to the current ingredients list.
                currentIngredients.Add(foodItem);

                // Check if the recipe can be cooked with the current ingredients.
                CheckRecipe();
            }
        }
    }
        

    // This method checks if the current ingredients match any recipe.
    void CheckRecipe()
    {
        // Iterate through all available recipes.
        foreach (Recipe recipe in recipeList)
        {

            // Check if the number of ingredients matches.
            if (recipe.ingredients.Count == currentIngredients.Count)
            {
                bool match = true;

                // Check if all ingredients in the recipe are present in the current ingredients.
                foreach (FoodItem ingredient in recipe.ingredients)
                {
                    if (!currentIngredients.Exists(item => item.itemName == ingredient.itemName))
                    {
                        match = false;
                        break;
                    }
                }

                // If all ingredients match, cook the recipe.
                if (match)
                {
                    Cook(recipe);
                    break;
                }
            }
        }
    }

    // This method handles the creation of the final food item
    // by destroying the ingredients and instantiating the result.
    void Cook(Recipe recipe)
    {
        // Destroy all current ingredients.
        foreach (FoodItem ingredient in currentIngredients)
        {
            Destroy(ingredient.gameObject);
        }

        // Clear the current ingredients list.
        currentIngredients.Clear();

        // Instantiate the resulting food item at the cooking station's position.
        FoodItem result = Instantiate(recipe.result, transform.position, Quaternion.identity);

        // Serve the dish to the current customer.
        if (currentCustomer != null)
        {
            currentCustomer.Serve(result);
        }
    }
}
