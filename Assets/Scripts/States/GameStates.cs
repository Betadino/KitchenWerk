using System;
using UnityEngine;

public class GamePlayingState : IGameStates
{
	public bool canChangeState = false;
	public void OnEnterState(GameStateManager gsManager)
	{
		GameStateManager.E_GamePaused += HandleGamePaused;
		canChangeState = false;
		Time.timeScale = 1;
	}

	public void OnUpdateState(GameStateManager gsManager)
	{
		if (canChangeState)
		{
			gsManager.SetState(new GamePausedState());
		}
	}

	public void OnExitState(GameStateManager gsManager)
	{
		GameStateManager.E_GamePaused -= HandleGamePaused;
	}

	public void HandleGamePaused()
	{
		canChangeState = true;
	}
}

public class GamePausedState : IGameStates
{
	private bool canChangeState = false;
	public void OnEnterState(GameStateManager gsManager)
	{
		GameStateManager.E_GameUnpaused += HandleGameUnpaused;
		canChangeState = false;
		Time.timeScale = 0;
	}

	public void OnUpdateState(GameStateManager gsManager)
	{
		if (canChangeState)
		{
			gsManager.SetState(new GamePlayingState());
		}
	}

	public void OnExitState(GameStateManager gsManager)
	{
		GameStateManager.E_GameUnpaused -= HandleGameUnpaused;
	}

	public void HandleGameUnpaused()
	{
		canChangeState = true;
	}
}