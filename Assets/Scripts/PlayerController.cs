using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    //_________________Movements____________________
    private IPlayerMovementStates currentMovementState;
    public PlayerIdleState playerIdleState = new();
    public PlayerWalkingState playerWalkingState = new();
    public PlayerRunningState playerRunningState = new();
    public PlayerDashingState playerDashingState = new();
    //_________________Interactions____________________
    private IPlayerInteractionStates currentInteractionState;
    public PlayerHandsFreeState playerHandsFreeState=new();
    
    public PlayerIsPickingState playerIsPickingState = new();


    public static bool PickUp;
    public void Start()
    {
        PickUp=false;
        currentMovementState = playerIdleState;
        currentMovementState.OnEnterState(this);
        currentInteractionState = playerHandsFreeState;
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("pickable"))
            {
    
                currentInteractionState.OnUpdateState(this, other);
            }
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

    public void SwitchInteractionState(IPlayerInteractionStates state)
    {
		currentInteractionState.OnExitState(this);
		currentInteractionState = state;
		currentInteractionState.OnEnterState(this);
	}
}
