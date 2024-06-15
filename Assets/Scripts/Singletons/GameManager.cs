using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region EVENTS
    public static event Action E_oven, E_orderDelivered; //eventos mid (tiago)
	public static event Action E_RemoveHP, E_GameOver; //eventos fixes (tomas)
    #endregion

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
	#region MONEY VARS
	[Header("HEALTH")]
	public int healthIncreaseLevel = 0;
	public int healthIncreaseMaxLevel = 2;
	public int healthIncreaseValue = 1;
	#endregion

	[Space(10)]
	#region BOOLS
	[Header("BOOLS")]
	public bool hasDash = false;
	public bool hasSprint = false;
    #endregion

    public static void SetOvenDoor()
    {
        E_oven?.Invoke();
    }

	  public static void OrderDelivered()
    {
        E_orderDelivered?.Invoke();
    }

    private void OnEnable()
	{
		UpgradeHandler.E_BoughtDash += SpendMoney;
		UpgradeHandler.E_BoughtSprint += SpendMoney;
		UpgradeHandler.E_BoughMoneyMult += LevelUpMoney;
		UpgradeHandler.E_BoughtScoreMult += LevelUpScore;
		UpgradeHandler.E_BoughtHealthIncrease += LevelUpHealth;
	}

	private void OnDisable()
	{
		UpgradeHandler.E_BoughtDash -= SpendMoney;
		UpgradeHandler.E_BoughtSprint -= SpendMoney;
		UpgradeHandler.E_BoughMoneyMult -= LevelUpMoney;
		UpgradeHandler.E_BoughtScoreMult -= LevelUpScore;
		UpgradeHandler.E_BoughtHealthIncrease -= LevelUpHealth;
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

	public void RemoveHP()
	{
		E_RemoveHP?.Invoke();
	}

	public void GainMoney()
	{
		money += Mathf.RoundToInt(defaultMoneyGain * moneyMultValue);
	}

	public void GainScore()
	{
		playerScore += Mathf.RoundToInt(defaultScoreValue * scoreMultLevel);
	}

	public void SpendMoney(int amount)
	{
		money -= amount;
	}

	public void LevelUpMoney(int amount)
	{
		money -= amount;
		if (moneyMultLevel < moneyMultMaxLevel)
		{
			moneyMultLevel += 1;
		}
	}

	public void LevelUpScore(int amount)
	{
		money -= amount;
		if (scoreMultLevel < scoreMultMaxLevel)
		{
			scoreMultLevel += 1;
		}
	}

	public void LevelUpHealth(int amount)
	{
		money -= amount;
		if (healthIncreaseLevel < healthIncreaseMaxLevel)
		{
			healthIncreaseLevel += 1;
		}
	}

	public void GameOver()
	{
		E_GameOver?.Invoke();
	}
	#endregion
}
