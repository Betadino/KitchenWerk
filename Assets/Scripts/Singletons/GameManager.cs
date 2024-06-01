using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	#region SCORE VARS
	[Header("SCORE")]
	public int playerScore = 0;
	public int defaultScoreValue = 100;
	public int scoreMultLevel = 0;
	public int scoreMultMaxLevel = 3;
	public float scoreMultValue = 1f;
	#endregion

	[Space(10)]
	#region MONEY VARS
	[Header("MONEY")]
	public int money = 0;
	public int defaultMoneyGain = 50;
	public int moneyMultLevel = 0;
	public int moneyMultMaxLevel = 3;
	public float moneyMultValue = 1f;
	#endregion

	[Space(10)]
	[Header("BOOLS")]
	public bool hasDash = false;
	public bool hasSprint = false;

	#region EVENTS
	public static event Action<int> E_BoughScoreMult;
	#endregion

	private void OnEnable()
	{
		UpgradeHandler.E_BoughtDash += SpendMoney;
		UpgradeHandler.E_BoughtSprint += SpendMoney;
	}

	private void OnDisable()
	{
		UpgradeHandler.E_BoughtDash -= SpendMoney;
		UpgradeHandler.E_BoughtSprint -= SpendMoney;
	}

	private void Update()
	{
		#region SCORE MULT LEVEL
		//Score Mult Value per Level
		switch (scoreMultLevel)
		{
			case 0:
				scoreMultValue = 1f;
				break;
			case 1:
				scoreMultValue = 1.33f;
				break;
			case 2:
				scoreMultValue = 1.66f;
				break;
			case 3:
				scoreMultValue = 2f;
				break;
		}
		#endregion

		#region MONEY MULT LEVEL
		//Score Mult Value per Level
		switch (moneyMultLevel)
		{
			case 0:
				moneyMultValue = 1f;
				break;
			case 1:
				moneyMultValue = 1.33f;
				break;
			case 2:
				moneyMultValue = 1.66f;
				break;
			case 3:
				moneyMultValue = 2f;
				break;
		}
		#endregion

		#region GAIN MONEY temp
		if (Input.GetKeyDown(KeyCode.M))
		{
			GainMoney();
		}
		#endregion
	}

	#region ADD STUFF
	public void AddScore()
	{
		playerScore += Mathf.RoundToInt(defaultScoreValue * scoreMultValue);
	}

	public void GainMoney()
	{
		money += Mathf.RoundToInt(defaultMoneyGain * moneyMultValue);
	}

	public void SpendMoney(int amount)
	{
		money -= amount;
	}
	#endregion
}
