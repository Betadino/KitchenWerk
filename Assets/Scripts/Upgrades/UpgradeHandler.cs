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
    public GameObject scoreMultText;

    //_______________Events______________________________
    public static event Action<int> E_BoughtDash;
    public static event Action<int> E_BoughtSprint;
    public static event Action<int> E_BoughScoreMult;

    //____________Upgrade Costs___________________________
    private int dashCost = 1000;
    private int sprintCost = 1000;
    private int scoreMultCost = 1000;

    //______________Bools________________________
    public static bool hasDash = false;
    public static bool hasSprint = false;

    private int scoreMultCurrentLevel = 0;
    private int scoreMultMaxLevel = 3;
    private float scoreMultValue = 1.25f;


    void Start()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.money.ToString();
        dashCostText.GetComponent<TextMeshProUGUI>().text = dashCost.ToString();
        sprintCostText.GetComponent<TextMeshProUGUI>().text = sprintCost.ToString();
    }

    void Update()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.money.ToString();
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

    public void BuyScoreMult()
    {
        E_BoughScoreMult?.Invoke(scoreMultCost);
    }
}
