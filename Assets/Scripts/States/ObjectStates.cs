using UnityEditor;
using UnityEngine;

public class ObjectIdleState : IObjectStates
{
    public void OnEnterState(ObjectController obj)
    {
        obj.circleCollider.isTrigger = false;
    }
    public void OnUpdateState(ObjectController obj)
    {
    }

    public void OnExitState(ObjectController obj)
    {
    }

}

public class ObjectGrabbedState : IObjectStates
{
    public void OnEnterState(ObjectController obj)
    {
        obj.circleCollider.isTrigger = true;
    }
    public void OnUpdateState(ObjectController obj)
    {
        obj.transform.position = obj.playerGrabArea.transform.position;
    }

    public void OnExitState(ObjectController obj)
    {
        //obj.transform.position = obj.transform.position;
    }

}