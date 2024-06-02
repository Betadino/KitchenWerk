using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OvenController : MonoBehaviour
{
    public Sprite[] ovenSprite;
    public  bool doorOpen;
    public bool isCooking;
    public OvenStatesHandler ovenStatesHandler = new();
    void Start()
    {   
        ovenStatesHandler = new();
        GameSubject.E_oven += HandleOvenDoor;
        ovenStatesHandler.SetState(new OvenClosedState(), this);
    }
    
     void OnDisable() {
        GameSubject.E_oven -= HandleOvenDoor;
    }



    void Update()
    {
        ovenStatesHandler.Update();
    }

    void HandleOvenDoor()
    {
        if (doorOpen)
        {
            ovenStatesHandler.SetState(new OvenClosedState(), this);
        } else {

            if(!isCooking)
            {
                 ovenStatesHandler.SetState(new OvenOpenState(), this);
            }
            
        }
    }
}
