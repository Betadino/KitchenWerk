using System.Threading;
using UnityEditor;
using UnityEngine;
//Oven States, different classes
public class OvenOpenState : IOvenState
{
    public void OnEnterState(OvenController oc)
    {
        oc.doorOpen = true;
        oc.gameObject.GetComponent<Collider2D>().isTrigger = true;
        oc.gameObject.GetComponent<SpriteRenderer>().sprite = oc.ovenSprite[0];
    }
    public void OnUpdateState(){}
    public void OnExitState(){}
}


public class OvenClosedState : IOvenState
{
    public void OnEnterState(OvenController oc)
    {
        oc.doorOpen=false;
        oc.gameObject.GetComponent<Collider2D>().isTrigger = false;
        oc.gameObject.GetComponent<SpriteRenderer>().sprite = oc.ovenSprite[1];
    }
    public void OnUpdateState()
    {
        
    }
    public void OnExitState(){}
}

public class OvenCookingState : IOvenState
{
    SpriteRenderer sr;
    OvenController _oc;
    //time of cooking 
    float timer = 4f;
    public void OnEnterState(OvenController oc)
    {
        _oc=oc;
        oc.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        oc.isCooking = true;
    }
    public void OnUpdateState(){
        timer-=Time.deltaTime;
        if(timer <0)
        {
           _oc.ovenStatesHandler.SetState(new OvenClosedState(), _oc);
        }
    }
    public void OnExitState(){
        sr.color = Color.green;
        _oc.isCooking = false;
    }
}