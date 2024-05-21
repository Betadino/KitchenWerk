public interface IGameStates
{
	void OnEnterState(GameStateManager gsManager);
	void OnUpdateState(GameStateManager gsManager);
	void OnExitState(GameStateManager gsManager);
}