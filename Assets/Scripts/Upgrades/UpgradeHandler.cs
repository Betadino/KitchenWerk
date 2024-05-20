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

    //_______________Events______________________________
    public static event Action<int> E_BoughtDash;
    public static event Action<int> E_BoughtSprint;

    //____________Upgrade Costs___________________________
    private int dashCost = 1000;
    private int sprintCost = 1000;

    //______________Bools________________________
    public static bool hasDash = false;
    public static bool hasSprint = false;


    void Start()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = MoneyHandler.currency.ToString();
        dashCostText.GetComponent<TextMeshProUGUI>().text = dashCost.ToString();
        sprintCostText.GetComponent<TextMeshProUGUI>().text = sprintCost.ToString();
    }

    void Update()
    {
        moneyText.GetComponent<TextMeshProUGUI>().text = MoneyHandler.currency.ToString();
    }

    public void BuyDash()
    {
        if (MoneyHandler.currency >= dashCost && !hasDash)
        {
            hasDash = true;
			E_BoughtDash?.Invoke(dashCost);
		}
    }

    public void BuySprint()
    {
        if (MoneyHandler.currency >= sprintCost && !hasSprint)
        {
            hasSprint = true;
			E_BoughtSprint?.Invoke(sprintCost);
		}
    }
}
