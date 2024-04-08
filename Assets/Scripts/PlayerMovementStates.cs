using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : IPlayerMovementStates
{
    public float horizontalValue;
    public float verticalValue;
    public Vector2 movement;

    public void OnEnterState(PlayerController player)
    {

    }

    public void OnUpdateState(PlayerController player)
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movement.x = horizontalValue;
        movement.y = verticalValue;


        //go to walk state
        if (movement.sqrMagnitude != 0)
        {
            player.SwitchState(player.playerWalkingState);
        }
    }

    public void OnFixedUpdate(PlayerController player)
    {

    }

    public void OnExitState(PlayerController player)
    {

    }
}

public class PlayerWalkingState : IPlayerMovementStates
{
    public float horizontalValue;
    public float verticalValue;
    public Vector2 movement;
    public float speed = 6f;
    public void OnEnterState(PlayerController player)
    {

    }

    public void OnUpdateState(PlayerController player)
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movement.x = horizontalValue;
        movement.y = verticalValue;
        movement = movement.normalized;

        //go back to idle
        if (movement.sqrMagnitude == 0)
        {
            player.SwitchState(player.playerIdleState);
        }

        //go to running state
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.SwitchState(player.playerRunningState);
        }
    }

    public void OnFixedUpdate(PlayerController player)
    {
        //move player
        if (movement.sqrMagnitude != 0)
        {
            player.rb.AddForce(movement * speed);
            //player.transform.position += player.transform.right * speed * movement.x * Time.deltaTime;
        }
    }

    public void OnExitState(PlayerController player)
    {

    }
}

public class PlayerRunningState : IPlayerMovementStates
{
    public float horizontalValue;
    public float verticalValue;
    public Vector2 movement;
    public float speed = 4f;
    public float runningModifier = 3f;

    public void OnEnterState(PlayerController player)
    {

    }

    public void OnUpdateState(PlayerController player)
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movement.x = horizontalValue;
        movement.y = verticalValue;
        movement = movement.normalized;

        //go back to idle
        if (movement.sqrMagnitude == 0)
        {
            player.SwitchState(player.playerIdleState);
        }
        //go back to running
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.SwitchState(player.playerWalkingState);
        }
    }

    public void OnFixedUpdate(PlayerController player)
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