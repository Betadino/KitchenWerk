using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeHandler : MonoBehaviour
{
    //____________Text______________________________
    public GameObject moneyText;
    public GameObject dashCostText;
    public GameObject sprintCostText;
    public GameObject moneyMultCostText;
    public GameObject moneyMultLevelText;
    public GameObject scoreMultCostText;
    public GameObject scoreMultLevelText;
    public GameObject healthIncreaseCostText;
    public GameObject healthIncreaseLevelText;

    //_______________Events______________________________
    public static event Action<int> E_BoughtDash;
    public static event Action<int> E_BoughtSprint;
    public static event Action<int> E_BoughMoneyMult;
    public static event Action<int> E_BoughtScoreMult;
    public static event Action<int> E_BoughtHealthIncrease;

    //____________Upgrade Costs___________________________
    private int dashCost = 800;
    private int sprintCost = 800;
    private int moneyMultCost = 1000;
    private int scoreMultCost = 1000;
    private int healthIncreaseCost = 1000;

    void Start()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.money.ToString();
        dashCostText.GetComponent<TextMeshProUGUI>().text = dashCost.ToString();
        sprintCostText.GetComponent<TextMeshProUGUI>().text = sprintCost.ToString();
		moneyMultCostText.GetComponent<TextMeshProUGUI>().text = moneyMultCost.ToString();
        moneyMultLevelText.GetComponent<TextMeshProUGUI>().text = "(" + GameManager.Instance.moneyMultLevel.ToString() + "/" + GameManager.Instance.moneyMultMaxLevel.ToString() + ")";
		scoreMultCostText.GetComponent<TextMeshProUGUI>().text = scoreMultCost.ToString();
		scoreMultLevelText.GetComponent<TextMeshProUGUI>().text = "(" + GameManager.Instance.scoreMultLevel.ToString() + "/" + GameManager.Instance.scoreMultMaxLevel.ToString() + ")";
		healthIncreaseCostText.GetComponent<TextMeshProUGUI>().text = healthIncreaseCost.ToString();
		healthIncreaseLevelText.GetComponent<TextMeshProUGUI>().text = "(" + GameManager.Instance.healthIncreaseLevel.ToString() + "/" + GameManager.Instance.healthIncreaseMaxLevel.ToString() + ")";

	}

	void Update()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.money.ToString();
		moneyMultLevelText.GetComponent<TextMeshProUGUI>().text = "(" + GameManager.Instance.moneyMultLevel.ToString() + "/" + GameManager.Instance.moneyMultMaxLevel.ToString() + ")";
		scoreMultLevelText.GetComponent<TextMeshProUGUI>().text = "(" + GameManager.Instance.scoreMultLevel.ToString() + "/" + GameManager.Instance.scoreMultMaxLevel.ToString() + ")";
		healthIncreaseLevelText.GetComponent<TextMeshProUGUI>().text = "(" + GameManager.Instance.healthIncreaseLevel.ToString() + "/" + GameManager.Instance.healthIncreaseMaxLevel.ToString() + ")";

		if (GameManager.Instance.hasDash)
        {
            dashCostText.GetComponent<TextMeshProUGUI>().text = "BOUGHT!";
        }

		if (GameManager.Instance.hasSprint)
		{
			sprintCostText.GetComponent<TextMeshProUGUI>().text = "BOUGHT!";
		}

		#region MONEY MULT
		switch (GameManager.Instance.moneyMultLevel)
        {
            case 0:
				moneyMultCost = 1000;
				moneyMultCostText.GetComponent<TextMeshProUGUI>().text = moneyMultCost.ToString();
				break;
            case 1:
				moneyMultCost = 1500;
				moneyMultCostText.GetComponent<TextMeshProUGUI>().text = moneyMultCost.ToString();
				break;
            case 2:
				moneyMultCost = 2000;
				moneyMultCostText.GetComponent<TextMeshProUGUI>().text = moneyMultCost.ToString();
				break;
            case 3:
				moneyMultCost = 0000;
				moneyMultCostText.GetComponent<TextMeshProUGUI>().text = "MAX!";
                break;
        }
		#endregion

		#region SCORE MULT
        switch (GameManager.Instance.scoreMultLevel)
        {
            case 0:
                scoreMultCost = 1000;
                scoreMultCostText.GetComponent<TextMeshProUGUI>().text = scoreMultCost.ToString();
                break;
            case 1:
				scoreMultCost = 1500;
				scoreMultCostText.GetComponent<TextMeshProUGUI>().text = scoreMultCost.ToString();
				break;
            case 2:
				scoreMultCost = 2000;
				scoreMultCostText.GetComponent<TextMeshProUGUI>().text = scoreMultCost.ToString();
				break;
            case 3:
				scoreMultCost = 0000;
				scoreMultCostText.GetComponent<TextMeshProUGUI>().text = "MAX!";
				break;
		}
		#endregion

		#region HEALTH
		switch (GameManager.Instance.healthIncreaseLevel)
		{
			case 0:
				healthIncreaseCost = 1000;
				healthIncreaseCostText.GetComponent<TextMeshProUGUI>().text = healthIncreaseCost.ToString();
				break;
			case 1:
				healthIncreaseCost = 1500;
				healthIncreaseCostText.GetComponent<TextMeshProUGUI>().text = healthIncreaseCost.ToString();
				break;
			case 2:
				healthIncreaseCost = 0000;
				healthIncreaseCostText.GetComponent<TextMeshProUGUI>().text = "MAX!";
				break;
		}
		#endregion
	}

	public void BuyDash()
    {
        if (GameManager.Instance.money >= dashCost && GameManager.Instance.hasDash == false)
        {
            GameManager.Instance.hasDash = true;
			E_BoughtDash?.Invoke(dashCost);
		}
    }

    public void BuySprint()
    {
        if (GameManager.Instance.money >= sprintCost && GameManager.Instance.hasSprint == false)
        {
            GameManager.Instance.hasSprint = true;
			E_BoughtSprint?.Invoke(sprintCost);
		}
    }

    public void BuyMoneyMult()
    {
        if (GameManager.Instance.money >= moneyMultCost && GameManager.Instance.moneyMultLevel < GameManager.Instance.moneyMultMaxLevel)
        {
			E_BoughMoneyMult?.Invoke(moneyMultCost);
		}
    }

    public void BuyScoreMult()
    {
        if (GameManager.Instance.money >= scoreMultCost && GameManager.Instance.scoreMultLevel < GameManager.Instance.scoreMultMaxLevel)
        {
            E_BoughtScoreMult?.Invoke(scoreMultCost);
        }
    }

	public void BuyHealthIncrease()
	{
		if (GameManager.Instance.money >= healthIncreaseCost && GameManager.Instance.healthIncreaseLevel < GameManager.Instance.healthIncreaseMaxLevel)
		{
			E_BoughtHealthIncrease?.Invoke(healthIncreaseCost);
		}
	}
}
