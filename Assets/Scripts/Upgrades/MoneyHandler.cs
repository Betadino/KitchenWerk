using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public static int currency = 0;

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

	void Start()
    {
        currency = 0;
    }

    void Update()
    {
        //temporary way to make money
        if (Input.GetKeyDown(KeyCode.M))
        {
            GainMoney(200);
        }
    }

    public void SpendMoney(int ammount)
    {
        currency -= ammount;
    }

    public void GainMoney(int ammount)
    {
        currency += ammount;
    }
}
