using System;
using System.Collections;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
	public static event Action E_GenerateOrder;
	public float orderInterval;


	public static void GenerateOrder()
	{
		E_GenerateOrder?.Invoke();
	}

	/*private void Start()
	{
		StartCoroutine(CallGenerateOrderEvent());
	}

	private IEnumerator CallGenerateOrderEvent()
	{
		while (true)
		{
			yield return new WaitForSeconds(orderInterval);

			E_GenerateOrder?.Invoke();
		}
	}*/
}
