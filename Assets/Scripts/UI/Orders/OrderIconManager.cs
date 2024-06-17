using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderIconManager : MonoBehaviour
{
    private float orderTime;
    private float timeRemaining;
    public Slider slider;

	private void OnEnable()
	{
        GameManager.E_orderDelivered += SelfDestruct;
	}

	private void OnDisable()
	{
		GameManager.E_orderDelivered -= SelfDestruct;
	}

	private void Start()
	{
        orderTime = GameManager.Instance.pizzaTimerToFailure;
        slider.maxValue = orderTime;
        timeRemaining = orderTime;
	}

	void Update()
    {
        Countdown();
        MoveSlider();
        CheckTimesUp();
    }

    private void Countdown()
    {
        timeRemaining -= Time.deltaTime;
    }

    private void CheckTimesUp()
    {
		if (timeRemaining <= 0)
		{
            GameManager.Instance.RemoveHP();
			GameManager.OrderDelivered();
			Destroy(gameObject);
		}
	}

    private void MoveSlider()
    {
        slider.value = timeRemaining;
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}