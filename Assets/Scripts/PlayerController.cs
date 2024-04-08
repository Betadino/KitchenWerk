using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private IPlayerMovementStates currentMovementState;
    private IPlayerInteractionStates currentInteractionState;
    public PlayerIdleState playerIdleState = new PlayerIdleState();
    public PlayerWalkingState playerWalkingState = new PlayerWalkingState();
    public PlayerRunningState playerRunningState = new PlayerRunningState();
    public PlayerDashingState playerDashingState = new PlayerDashingState();

    public void Start()
    {
        currentMovementState = playerIdleState;
        currentMovementState.OnEnterState(this);
    }

    public void Update()
    {
        currentMovementState.OnUpdateState(this);
    }

    public void FixedUpdate()
    {
        currentMovementState.OnFixedUpdate(this);
    }

    public void SwitchMovementState(IPlayerMovementStates state)
    {
        currentMovementState.OnExitState(this);
        currentMovementState = state;
        currentMovementState.OnEnterState(this);
    }

    public void SwitchInteractionStates(IPlayerInteractionStates state)
    {
		currentInteractionState.OnExitState(this);
		currentInteractionState = state;
		currentInteractionState.OnEnterState(this);
	}
}
