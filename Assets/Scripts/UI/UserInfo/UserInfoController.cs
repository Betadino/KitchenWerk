using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInfoController : MonoBehaviour
{
    public TextMeshProUGUI scoreText, moneyText, healthText;
    private int healthAmount = 0;

	private void OnEnable()
	{
        UpgradeHandler.E_BoughtHealthIncrease += AddHealthToText;
		GameManager.E_RemoveHP += RemoveHealthFromText;
	}

	private void OnDisable()
	{
		UpgradeHandler.E_BoughtHealthIncrease -= AddHealthToText;
		GameManager.E_RemoveHP -= RemoveHealthFromText;
	}

	void Start()
    {
        healthAmount = GameManager.Instance.healthIncreaseLevel + 1;
        scoreText.text = GameManager.Instance.playerScore.ToString();
        moneyText.text = GameManager.Instance.money.ToString();
        healthText.text = healthAmount.ToString();
    }

    void Update()
    {
		scoreText.text = GameManager.Instance.playerScore.ToString();
		moneyText.text = GameManager.Instance.money.ToString();
		healthText.text = healthAmount.ToString();
	}

    void AddHealthToText(int i)
    {
        healthAmount += 1;
    }
	void RemoveHealthFromText()
	{
		healthAmount -= 1;
	}
}
