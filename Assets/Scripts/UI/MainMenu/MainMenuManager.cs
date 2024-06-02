using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private IMainMenuStates currentState;

    [Header("SCREENS")]
	#region SCREENS
	public GameObject mainMenuScreen;
    public GameObject helpMenuScreen;
    #endregion

    #region EVENTS
    public static event Action E_LoadGame;
    public static event Action E_LoadMainScreen;
    public static event Action E_LoadHelpScreen;
    public static event Action E_QuitGame;
	#endregion

	void Start()
    {
        SetState(new MainMenu_MainScreenState());
    }

    void Update()
    {
        currentState.OnUpdateState(this);
    }

    public void SetState(IMainMenuStates state)
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

    public void LoadGame()
    {
        E_LoadGame?.Invoke();
    }

    public void LoadMainScreen()
    {
        E_LoadMainScreen?.Invoke();
    }

    public void LoadHelpScreen()
    {
        E_LoadHelpScreen?.Invoke();
    }

    public void QuitGame()
    {
        E_QuitGame?.Invoke();
    }
}
