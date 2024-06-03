using System.Threading;
using UnityEditor;
using UnityEngine;
//Oven States, different classes
public class OvenOpenState : IOvenState
{
    public void OnEnterState(OvenController oc)
    {
        oc.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
        oc.doorOpen = true;
        //oc.gameObject.GetComponent<Collider2D>().isTrigger = true;
        oc.gameObject.GetComponent<SpriteRenderer>().sprite = oc.ovenSprite[1];
    }
    public void OnUpdateState(){}
    public void OnExitState(){}
}


public class OvenClosedState : IOvenState
{
    public void OnEnterState(OvenController oc)
    {
        oc.doorOpen=false;
        //oc.gameObject.GetComponent<Collider2D>().isTrigger = false;
        oc.gameObject.GetComponent<SpriteRenderer>().sprite = oc.ovenSprite[0];
        if(oc.isPizzaInside&& !oc.isCooked)
        {
            oc.ovenStatesHandler.SetState(new OvenCookingState(), oc );
        }
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
        sr = oc.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        oc.isCooking = true;
    }
    public void OnUpdateState()
    {
        timer-=Time.deltaTime;
        Debug.Log(timer);
        if(timer <0)
        {
            _oc.isCooked = true;
            _oc.ovenStatesHandler.SetState(new OvenClosedState(), _oc);
           
        }
    }
    public void OnExitState(){
        sr.color = Color.green;
        _oc.isCooking = false;
        GameObject.Instantiate(_oc.currentPizza.GetComponent<IngPrefab>().Prefab, _oc.gameObject.transform.position, Quaternion.identity);
        GameObject.Destroy(_oc.currentPizza);
    }
}