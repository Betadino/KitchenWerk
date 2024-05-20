using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public GameObject playerGrabArea;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    public bool inRange = false;

    //-------------- STATES -----------------//
    private IObjectStates currentState;
    public ObjectIdleState idleState = new();
    public ObjectGrabbableState grabbableState = new();
    public ObjectGrabbedState grabbedState = new();

    //____________PauseBools____________
    private bool gameIsPaused = false;

	private void OnEnable()
	{
        GameStateManager.E_GamePaused += HandleGamePaused;
        GameStateManager.E_GameUnpaused += HandleGameUnpaused;
	}

	private void OnDisable()
	{
		GameStateManager.E_GamePaused -= HandleGamePaused;
		GameStateManager.E_GameUnpaused -= HandleGameUnpaused;
	}

	void Start()
    {
        currentState = idleState;
        currentState.OnEnterState(this);
        playerGrabArea = GameObject.Find("HoldArea");
        player = GameObject.Find("Player");
    }

    void Update()
    {
        currentState.OnUpdateState(this);
	}

    public void SwitchState(IObjectStates state)
    {
        if (!gameIsPaused)
        {
			if (currentState != null)
			{
				currentState.OnExitState(this);
			}

			currentState = state;

			if (currentState != null)
			{
				currentState.OnEnterState(this);
			}
		}
    }

    public void HandleGamePaused()
    {
        gameIsPaused = true;
    }

    public void HandleGameUnpaused()
    {
        gameIsPaused = false;
    }
}
