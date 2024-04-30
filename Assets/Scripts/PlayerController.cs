using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Vector2 lookDirection;
    public Vector2 mousePosition;
    public Camera camera;

    //________________Upgrade Bools________________
    public bool upg_hasRun = false;
    public bool upg_hasDash = false;

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

    public GameObject holdArea;
    public GameObject currentItem = null;

    public void Start()
    {
        SwitchMovementState(playerIdleState);
        SwitchInteractionState(playerHandsFreeState);
    }

    public void Update()
    {
        RotateToMouse(); //aponta o jogador na direcao do rato

        currentMovementState.OnUpdateState(this);
        currentInteractionState.OnUpdateState(this);
    }

    public void FixedUpdate()
    {
        currentMovementState.OnFixedUpdate(this);
    }

    public void SwitchMovementState(IPlayerMovementStates state)
    {
        if (currentMovementState != null)
        {
			currentMovementState.OnExitState(this);
		}
        currentMovementState = state;
        if (currentMovementState != null)
        {
			currentMovementState.OnEnterState(this);
		}
    }

    public void SwitchInteractionState(IPlayerInteractionStates state)
    {
        if (currentInteractionState != null)
        {
			currentInteractionState.OnExitState(this);
		}
		
		currentInteractionState = state;
        if (currentInteractionState != null)
        {
			currentInteractionState.OnEnterState(this);
		}
	}

    //funcao de rodar o jogador
    public void RotateToMouse()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - rb.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }
}
