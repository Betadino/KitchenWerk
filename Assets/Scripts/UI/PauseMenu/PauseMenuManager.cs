using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PauseMenuManager : MonoBehaviour
{
    private IPauseMenuStates currentState;
    public GameObject mainScreen;
    public GameObject helpScreen;
    public GameObject upgradeScreen;

    //___________External Pause Event Stuff___________
    public GameObject objWithGameStateManager;
    private GameStateManager gsManager;

    //__________Actual Pause Menu Events Stuff__________
    public static event Action E_loadPauseMainScreen;
	public static event Action E_loadPauseHelpScreen;
	public static event Action E_loadPauseUpgradeScreen;

	private void OnEnable()
	{
        GameStateManager.E_GameUnpaused += HandleForcedUnpause;
	}

	private void OnDisable()
	{
		GameStateManager.E_GameUnpaused += HandleForcedUnpause;
	}

	void Start()
    {
        mainScreen.SetActive(true);
        gsManager = objWithGameStateManager.GetComponent<GameStateManager>();
        SetState(new PauseMainScreenState());
    }

    void Update()
    {
        currentState.OnUpdateState(this);
    }

    public void SetState(IPauseMenuStates state)
    {
        if (currentState != null)
        {
            currentState.OnExitState(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnterState(this);
        }
    }


	#region Event Functions
    public void HandleForcedUnpause()
    {
        SetState(new PauseMainScreenState());
    }

	public void UnpauseGame()
    {
        gsManager.ExternalUnpauseEvent();
    }

    public void LoadMainScreen()
    {
        E_loadPauseMainScreen?.Invoke();
    }

    public void LoadHelpScreen()
    {
        E_loadPauseHelpScreen?.Invoke();
    }

    public void LoadUpgradeScreen()
    {
        E_loadPauseUpgradeScreen?.Invoke();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
	#endregion
}
