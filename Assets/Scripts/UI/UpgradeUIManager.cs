using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject upgradesScreen;
    private GameObject player;
    private PlayerController playerController;

    void Awake()
    {
        TurnOffUpgradesScreen();
        TurnOnMainScreen();
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    #region UI Functions
    public void TurnOnMainScreen()
    {
        mainScreen.SetActive(true);
    }

    public void TurnOffMainScreen()
    {
        mainScreen.SetActive(false);
    }

    public void TurnOnUpgradesScreen()
    {
        upgradesScreen.SetActive(true);
    }

    public void TurnOffUpgradesScreen()
    {
        upgradesScreen.SetActive(false);
    }
    #endregion

    #region Upgrade Functions
    public void GiveRun()
    {
        playerController.upg_hasRun = true;
        TurnOffUpgradesScreen();
        TurnOnMainScreen();
    }

    public void GiveDash()
    {
        playerController.upg_hasDash = true;
        TurnOffUpgradesScreen();
        TurnOnMainScreen();
    }
    #endregion
}
