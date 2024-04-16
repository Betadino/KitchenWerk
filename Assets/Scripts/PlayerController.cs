using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Vector2 lookDirection;
    public Vector2 mousePosition;
    public Camera camera;

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
    public static bool hasItem = false;
    public static bool canPickup;

    public void Start()
    {
        canPickup=false;
        currentMovementState = playerIdleState;
        currentMovementState.OnEnterState(this);
        currentInteractionState = playerHandsFreeState;
    }

    public void Update()
    {
        if (currentItem)
        {
            Debug.Log(currentItem.name);
        }
        
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

    //funcao de rodar o jogador
    public void RotateToMouse()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - rb.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }

	public void OnTriggerExit2D(Collider2D collision)
	{
        currentItem = null;
        canPickup = false;
	}
}
