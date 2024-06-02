using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_MainScreenState : IMainMenuStates
{
	private bool canLoadHelp = false;
	public void OnEnterState(MainMenuManager manager)
	{
		#region EventSubscribers
		MainMenuManager.E_LoadGame += HandleLoadGame;
		MainMenuManager.E_QuitGame += HandleQuitGame;
		MainMenuManager.E_LoadHelpScreen += HandleLoadHelpScreen;
		#endregion
		manager.mainMenuScreen.SetActive(true);
		canLoadHelp = false;
	}

	public void OnUpdateState(MainMenuManager manager)
	{
		if (canLoadHelp)
		{
			manager.SetState(new MainMenu_HelpScreenState());
		}
	}

	public void OnExitState(MainMenuManager manager)
	{
		#region EventUnsubscribers
		MainMenuManager.E_LoadGame -= HandleLoadGame;
		MainMenuManager.E_QuitGame -= HandleQuitGame;
		MainMenuManager.E_LoadHelpScreen -= HandleLoadHelpScreen;
		#endregion
		manager.mainMenuScreen.SetActive(false);
	}

	#region Event Handlers
	private void HandleLoadGame()
	{
		SceneManager.LoadScene("TomasTesting");
	}

	private void HandleQuitGame()
	{
		Application.Quit();
	}

	private void HandleLoadHelpScreen()
	{
		canLoadHelp = true;
	}
	#endregion
}

public class MainMenu_HelpScreenState : IMainMenuStates
{
	private bool canLoadMain = false;
	public void OnEnterState(MainMenuManager manager)
	{
		#region EventSubscribers
		MainMenuManager.E_LoadMainScreen += HandleLoadMainScreen;
		#endregion
		manager.helpMenuScreen.SetActive(true);
		canLoadMain = false;
	}

	public void OnUpdateState(MainMenuManager manager)
	{
		if (canLoadMain)
		{
			manager.SetState(new MainMenu_MainScreenState());
		}
	}

	public void OnExitState(MainMenuManager manager)
	{
		#region EventUnsubscribers
		MainMenuManager.E_LoadMainScreen -= HandleLoadMainScreen;
		#endregion
		manager.helpMenuScreen.SetActive(false);
	}

	#region Event Handlers
	private void HandleLoadMainScreen()
	{
		canLoadMain = true;
	}
	#endregion
}