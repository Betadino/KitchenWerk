using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandsFreeState : IPlayerInteractionStates
{

    public void OnEnterState(PlayerController player)
    {

    }

    public void OnUpdateState(PlayerController player, Collider2D collider) 
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("yes");
            collider.gameObject.transform.SetParent(player.transform, true);
        }
    }

    public void OnExitState(PlayerController player)
    {

    }
    

    
}

public class PlayerIsPickingState : IPlayerInteractionStates
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