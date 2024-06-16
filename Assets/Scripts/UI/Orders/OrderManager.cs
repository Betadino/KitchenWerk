using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
	private bool hasOrder = false;
	[Header("Recipes and Customers")]
	public List<Recipe> availableRecipes;
	public Customer customer;

	[Space(20)]
	[Header("Order UI Objects")]
	[Space(5)]
	public Transform uiParentTransform;
	public List<GameObject> orderUIObjects;

	private void OnEnable()
	{
		OrderGenerator.E_GenerateOrder += GenerateRandomOrders;
		SpawnCustomer.E_ReceiveCustomer += ReceiveCustomer;
	}

	private void OnDisable()
	{
		OrderGenerator.E_GenerateOrder -= GenerateRandomOrders;
		SpawnCustomer.E_ReceiveCustomer -= ReceiveCustomer;
	}

	private void ReceiveCustomer(GameObject newCustomer)
	{
		customer = newCustomer.GetComponent<Customer>();
	}

	public void GenerateRandomOrders()
	{
		Recipe randomRecipe = availableRecipes[Random.Range(0, availableRecipes.Count)];
		GameManager.Instance.currentOrder = new Order(randomRecipe.recipeName, randomRecipe);
		/*if(customer != null)
		{
			customer.currentOrder = new Order(randomRecipe.recipeName, randomRecipe);
		}
		else
		{
			Debug.Log("what the fuck");
		}
		Debug.Log(customer.currentOrder.orderName);*/
		GameObject orderUIObject = null;

		switch (GameManager.Instance.currentOrder.orderName)
		{
			case null:
				Debug.Log("what the fuck");
				break;
			case "BaconPizza":
				Debug.Log("BACON PIZZA");
				orderUIObject = orderUIObjects[0];
				Instantiate(orderUIObject, uiParentTransform);
				break;
			case "PepperoniPizza":
				Debug.Log("PEPPERONI PIZZA");
				orderUIObject = orderUIObjects[1];
				Instantiate(orderUIObject, uiParentTransform);
				break;
			case "MushroomPizza":
				Debug.Log("MUSHROOM PIZZA");
				orderUIObject = orderUIObjects[2];
				Instantiate(orderUIObject, uiParentTransform);
				break;
			case "MargheritaPizza":
				Debug.Log("MARGHERITA PIZZA");
				orderUIObject = orderUIObjects[3];
				Instantiate(orderUIObject, uiParentTransform);
				break;
		}

		/*if (orderUIObject != null)
		{
			Instantiate(orderUIObject, uiParentTransform);
		}*/
	}
}
