using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
	[Header("Recipes and Customers")]
	public List<Recipe> availableRecipes;
	public List<Customer> customers;

	[Space(20)]
	[Header("Order UI Objects")]
	[Space(5)]
	public Transform uiParentTransform;
	public List<GameObject> orderUIObjects;

	private void OnEnable()
	{
		OrderGenerator.E_GenerateOrder += GenerateRandomOrders;
	}

	private void OnDisable()
	{
		OrderGenerator.E_GenerateOrder -= GenerateRandomOrders;
	}

	public void GenerateRandomOrders()
	{
		foreach (Customer customer in customers)
		{
			Recipe randomRecipe = availableRecipes[Random.Range(0, availableRecipes.Count)];
			customer.currentOrder = new Order(randomRecipe.recipeName, randomRecipe);
			GameObject orderUIObject = null;

			switch (randomRecipe.recipeName)
			{
				case "BaconPizza":
					Debug.Log("BACON PIZZA");
					orderUIObject = orderUIObjects[0];
					break;
				case "PepperoniPizza":
					Debug.Log("PEPPERONI PIZZA");
					orderUIObject = orderUIObjects[1];
					break;
				case "MushroomPizza":
					Debug.Log("MUSHROOM PIZZA");
					orderUIObject = orderUIObjects[2];
					break;
				case "MargheritaPizza":
					Debug.Log("MARGHERITA PIZZA");
					orderUIObject = orderUIObjects[3];
					break;
			}

			if (orderUIObject != null)
			{
				Instantiate(orderUIObject, uiParentTransform);
			}
		}
	}
}
