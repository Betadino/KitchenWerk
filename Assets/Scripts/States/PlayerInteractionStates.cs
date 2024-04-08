using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerHandsFreeState : IPlayerInteractionStates
{

    public void OnEnterState(PlayerController player)
    {
        PlayerController.canPickup = true;
    }

    public void OnUpdateState(PlayerController player) 
    {
		if (Input.GetKeyDown(KeyCode.E) && PlayerController.canPickup)
		{
            PickupItem(player, player.currentItem);
		}
	}

    public void OnExitState(PlayerController player)
    {

    }

    public void PickupItem(PlayerController player, GameObject item)
    {
		item.transform.SetParent(player.transform, true);
        item.transform.position = player.holdArea.transform.position;
        player.currentItem = item;
        PlayerController.canPickup = false;
        //item.layer = LayerMask.NameToLayer("IgnoreChildren");
        player.SwitchInteractionState(player.playerIsPickingState);
    }
}

public class PlayerIsPickingState : IPlayerInteractionStates
{


    public void OnEnterState(PlayerController player)
    {

    }

    public void OnUpdateState(PlayerController player)
    {
        PlayerController.canPickup = false;
        if (Input.GetKeyDown(KeyCode.E))
		{
            GiveForAdoption(player, player.currentItem);
        }
	}

    public void OnExitState(PlayerController player)
    {

    }

    public void GiveForAdoption(PlayerController player, GameObject item)
    {
        player.currentItem = null;
		item.transform.parent = null;
        //item.gameObject.layer = LayerMask.NameToLayer("Default");
        player.SwitchInteractionState(player.playerHandsFreeState);
    }
}