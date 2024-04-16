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
		//CheckPlayerDist();
	}

    public void SwitchState(IObjectStates state)
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
