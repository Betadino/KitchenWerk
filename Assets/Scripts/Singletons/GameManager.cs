using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public int defaultMoneyGain = 100;
	public int moneyMultLevel = 0;
	public int moneyMultMaxLevel = 3;
	public float moneyMultValue = 1f;
	#endregion

	[Space(10)]
	#region HEALTH VARS
	[Header("HEALTH")]
	public int playerHealth = 1;
	public int healthIncreaseLevel = 0;
	public int healthIncreaseMaxLevel = 2;
	public int healthIncreaseValue = 1;
	#endregion

	[Space(10)]
	#region BOOLS
	[Header("BOOLS")]
	public bool hasDash = false;
	public bool hasSprint = false;
	private bool isDead = false;
	private bool canLoadLoseScene = true;
    #endregion

	[Space(10)]
	#region TIMERS
	[Header("TIMERS")]
	public float ovenTimer = 4f;
	public float pizzaTimerToFailure = 45f;
	#endregion

	[Space(10)]
	#region ORDERS
	[Header("ORDERS")]
	public Order currentOrder = null;
	public int ordersCompleted = 0;
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
		#region GAME OVER CHECKER
		if (playerHealth == 0)
		{
			isDead = true;
		}

		if (isDead && canLoadLoseScene)
		{
			GameOver();
			canLoadLoseScene = false;
		}
		#endregion

		#region TIMER REDUCER
		if (ordersCompleted > 9)
		{
			pizzaTimerToFailure -= 2;
			ordersCompleted = 0;
		}
		#endregion

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
	public void RemoveHP()
	{
		playerHealth -= 1;
	}

	public void GainMoney()
	{
		money += Mathf.RoundToInt(defaultMoneyGain * moneyMultValue);
	}

	public void GainScore()
	{
		Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAA");
		playerScore += Mathf.RoundToInt(defaultScoreValue * scoreMultValue);
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
			playerHealth += 1;
		}
	}

	public void GameOver()
	{
		SceneManager.LoadScene("LoseScene");
	}
	#endregion
}
