using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private IGameStates currentState;
    public GameObject pauseMenu;

    //_________Game Pause events and stuff_____________
	public static event Action E_GamePaused;
	public static event Action E_GameUnpaused;
	private bool gameIsPaused = false;

	void Start()
    {
        SetState(new GamePlayingState());
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        currentState.OnUpdateState(this);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused) //pause game if unpaused
            {
                gameIsPaused = true;
                E_GamePaused?.Invoke();
            }
            else //do the opposite
            {
                gameIsPaused = false;
                E_GameUnpaused?.Invoke();
            }
        }

        if (gameIsPaused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }

    public void SetState(IGameStates state)
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

    //function to invoke event outside of this script
    public void ExternalUnpauseEvent()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            E_GameUnpaused?.Invoke();
        }
    }
}
