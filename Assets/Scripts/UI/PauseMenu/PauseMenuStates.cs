public class PauseMainScreenState :IPauseMenuStates
{
	private enum Screens {Main, Help, Upgrade};
	private Screens selectedScreen;
	public void OnEnterState(PauseMenuManager manager)
	{
		manager.mainScreen.SetActive(true);
		selectedScreen = Screens.Main;
		PauseMenuManager.E_loadPauseHelpScreen += HandleHelpScreenSelected;
		PauseMenuManager.E_loadPauseUpgradeScreen += HandleUpgradeScreenSelected;
	}

	public void OnUpdateState(PauseMenuManager manager)
	{
		switch (selectedScreen)
		{
			case Screens.Main:
				break;
			case Screens.Help:
				manager.SetState(new PauseHelpScreenState());
				break;
			case Screens.Upgrade:
				manager.SetState(new PauseUpgradeScreenState());
				break;
		}
	}

	public void OnExitState(PauseMenuManager manager)
	{
		manager.mainScreen.SetActive(false);
		PauseMenuManager.E_loadPauseHelpScreen -= HandleHelpScreenSelected;
		PauseMenuManager.E_loadPauseUpgradeScreen -= HandleUpgradeScreenSelected;
	}

	public void HandleHelpScreenSelected()
	{
		selectedScreen = Screens.Help;
	}

	public void HandleUpgradeScreenSelected()
	{
		selectedScreen = Screens.Upgrade;
	}
}

public class PauseHelpScreenState : IPauseMenuStates
{
	private bool canReturn = false;
	public void OnEnterState(PauseMenuManager manager)
	{
		manager.helpScreen.SetActive(true);
		canReturn = false;
		PauseMenuManager.E_loadPauseMainScreen += HandleMainScreenSelected;
	}

	public void OnUpdateState(PauseMenuManager manager)
	{
		if (canReturn)
		{
			manager.SetState(new PauseMainScreenState());
		}
	}

	public void OnExitState(PauseMenuManager manager)
	{
		manager.helpScreen.SetActive(false);
		PauseMenuManager.E_loadPauseMainScreen -= HandleMainScreenSelected;
	}

	public void HandleMainScreenSelected()
	{
		canReturn = true;
	}
}

public class PauseUpgradeScreenState : IPauseMenuStates
{
	private bool canReturn = false;
	public void OnEnterState(PauseMenuManager manager)
	{
		manager.upgradeScreen.SetActive(true);
		canReturn = false;
		PauseMenuManager.E_loadPauseMainScreen += HandleMainScreenSelected;
	}

	public void OnUpdateState(PauseMenuManager manager)
	{
		if (canReturn)
		{
			manager.SetState(new PauseMainScreenState());
		}
	}

	public void OnExitState(PauseMenuManager manager)
	{
		manager.upgradeScreen.SetActive(false);
		PauseMenuManager.E_loadPauseMainScreen -= HandleMainScreenSelected;
	}

	public void HandleMainScreenSelected()
	{
		canReturn = true;
	}
}