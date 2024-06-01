using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : IPlayerMovementStates
{
    public float horizontalValue;
    public float verticalValue;
    public Vector2 movement;

    public void OnEnterState (PlayerController player)
    {
        player.spriteRenderer.color = Color.green;
    }

    public void OnUpdateState (PlayerController player)
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movement.x = horizontalValue;
        movement.y = verticalValue;


        //go to walk state
        if (movement.sqrMagnitude != 0)
        {
            player.SwitchMovementState(player.playerWalkingState);
        }
    }

    public void OnFixedUpdate (PlayerController player)
    {

    }

    public void OnExitState (PlayerController player)
    {

    }
}

public class PlayerWalkingState : IPlayerMovementStates
{
    public float horizontalValue;
    public float verticalValue;
    public Vector2 movement;

    public void OnEnterState (PlayerController player)
    {
        player.spriteRenderer.color = Color.blue;
    }

    public void OnUpdateState (PlayerController player)
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movement.x = horizontalValue;
        movement.y = verticalValue;
        movement = movement.normalized;

        //go back to idle
        if (movement.sqrMagnitude == 0)
        {
            player.SwitchMovementState(player.playerIdleState);
        }

        //go to running state
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(player.upg_hasSprint)
            {
                player.SwitchMovementState(player.playerRunningState);
            }
        }

        //go to dashing state
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.upg_hasDash)
            {
                player.SwitchMovementState(player.playerDashingState);
            }
		}
    }

    public void OnFixedUpdate (PlayerController player)
    {
        //move player
        if (movement.sqrMagnitude != 0)
        {
            player.rb.AddForce(movement * player.speed);
            //player.transform.position += player.transform.right * speed * movement.x * Time.deltaTime;
        }
    }

    public void OnExitState (PlayerController player)
    {

    }
}

public class PlayerRunningState : IPlayerMovementStates
{
    public float horizontalValue;
    public float verticalValue;
    public Vector2 movement;
    public float speed = 2f;
    public float runningModifier = 2f;

    public void OnEnterState (PlayerController player)
    {
        player.spriteRenderer.color = Color.red;
    }

    public void OnUpdateState (PlayerController player)
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movement.x = horizontalValue;
        movement.y = verticalValue;
        movement = movement.normalized;

        //go back to idle
        if (movement.sqrMagnitude == 0)
        {
            player.SwitchMovementState(player.playerIdleState);
        }
        //go back to running
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.SwitchMovementState(player.playerWalkingState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
			player.SwitchMovementState(player.playerDashingState);
		}
    }

    public void OnFixedUpdate (PlayerController player)
    {
        //move player
        if (movement.sqrMagnitude != 0)
        {
            player.rb.AddForce(movement * (speed * runningModifier));
            //player.transform.position += player.transform.right * (speed * runningModifier) * movement.x * Time.deltaTime;
        }
    }

    public void OnExitState(PlayerController player)
    {

    }
}

public class PlayerDashingState : IPlayerMovementStates
{
	public float horizontalValue;
	public float verticalValue;
	public Vector2 movement;

	public void OnEnterState(PlayerController player)
	{
        player.spriteRenderer.color = Color.yellow;
		horizontalValue = Input.GetAxisRaw("Horizontal");
		verticalValue = Input.GetAxisRaw("Vertical");

		movement.x = horizontalValue;
		movement.y = verticalValue;
		movement = movement.normalized;

		player.rb.AddForce(movement * 2f, ForceMode2D.Impulse);
	}

	public void OnUpdateState(PlayerController player)
	{
		player.SwitchMovementState(player.playerIdleState);
	}

	public void OnFixedUpdate(PlayerController player)
	{

	}

	public void OnExitState(PlayerController player)
	{

	}
}

public class PlayerPausedState : IPlayerMovementStates
{
    public void OnEnterState(PlayerController player)
    {

    }

	public void OnUpdateState(PlayerController player)
	{

	}

	public void OnExitState(PlayerController player)
	{

	}
}