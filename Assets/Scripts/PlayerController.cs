using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    public float speed = 1f;
    public int playerHP = 0;

    [Space(20)]
    [Header("Debugs")]
    public GameObject player;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Vector2 lookDirection;
    public Vector2 mousePosition;
    private Camera camera;

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

    //___________________PauseBools______________________
    private bool gameIsPaused = false;

    public GameObject holdArea;
    public GameObject currentItem = null;

	private void OnEnable()
	{
        GameStateManager.E_GamePaused += HandleGamePaused;
        GameStateManager.E_GameUnpaused += HandleGameUnpaused;
        //UpgradeHandler.E_BoughtHealthIncrease += UpdatePlayerHP;
	}

	private void OnDisable()
	{
		GameStateManager.E_GamePaused -= HandleGamePaused;
		GameStateManager.E_GameUnpaused -= HandleGameUnpaused;
		//UpgradeHandler.E_BoughtHealthIncrease -= UpdatePlayerHP;
	}

	public void Start()
    {
        SwitchMovementState(playerIdleState);
        SwitchInteractionState(playerHandsFreeState);
        camera = Camera.main;
        playerHP = GameManager.Instance.playerHealth;
    }

    public void Update()
    {
        RotateToMouse(); //aponta o jogador na direcao do rato
        CheckPlayerHP();

        currentMovementState.OnUpdateState(this);
        currentInteractionState.OnUpdateState(this);
    }

    public void FixedUpdate()
    {
        currentMovementState.OnFixedUpdate(this);
    }

    public void SwitchMovementState(IPlayerMovementStates state)
    {
		if (!gameIsPaused)
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
    }

    public void SwitchInteractionState(IPlayerInteractionStates state)
    {
        if (!gameIsPaused)
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
	}

	#region Event Handlers
	public void HandleGamePaused()
	{
		gameIsPaused = true;
	}

	public void HandleGameUnpaused()
	{
		gameIsPaused = false;
	}
	#endregion

	//funcao de rodar o jogador
	public void RotateToMouse()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - rb.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }

    private void CheckPlayerHP()
    {
        if (playerHP <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    /*private void UpdatePlayerHP(int healthAmount)
    {
        healthAmount = GameManager.Instance.healthIncreaseValue;
        playerHP += healthAmount;
    }*/
}
