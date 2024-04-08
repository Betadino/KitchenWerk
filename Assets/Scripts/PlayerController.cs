using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    private IPlayerMovementStates currentState;
    public PlayerIdleState playerIdleState = new PlayerIdleState();
    public PlayerWalkingState playerWalkingState = new PlayerWalkingState();
    public PlayerRunningState playerRunningState = new PlayerRunningState();

    public void Start()
    {
        currentState = playerIdleState;
        currentState.OnEnterState(this);
    }

    public void Update()
    {
        currentState.OnUpdateState(this);
    }

    public void FixedUpdate()
    {
        currentState.OnFixedUpdate(this);
    }

    public void SwitchState(IPlayerMovementStates state)
    {
        currentState.OnExitState(this);
        currentState = state;
        currentState.OnEnterState(this);
    }
}
