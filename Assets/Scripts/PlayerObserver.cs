using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver
{
    PlayerController playerController = new();
    public void SubscribeEvent()
    {
        PlayerSubject.E_TestEvent += HandleEvent;
    }

    public void UnsubscribeEvent() 
    {
        PlayerSubject.E_TestEvent -= HandleEvent;
    }

    public void HandleEvent()
    {
        playerController.SwitchInteractionState(playerController.playerIsPickingState);
        Debug.Log("FIZ UMA CENA");
    }
}
