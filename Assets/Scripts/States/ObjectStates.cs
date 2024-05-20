using UnityEditor;
using UnityEngine;

public class ObjectIdleState : IObjectStates
{
	private float distance = 0f;
	private float minDistance = 0f;
    public void OnEnterState(ObjectController obj)
    {
        obj.circleCollider.isTrigger = false;
		obj.inRange = false;
		minDistance = obj.transform.localScale.x * 3;
    }
    public void OnUpdateState(ObjectController obj)
    {
		obj.spriteRenderer.color = Color.red;
		distance = CheckPlayerDist(obj.transform.position, obj.player.transform.position);
		if (distance <= minDistance)
		{
			obj.SwitchState(obj.grabbableState);
		}
	}

    public void OnExitState(ObjectController obj)
    {

    }

	public float CheckPlayerDist(Vector3 objPos, Vector3 playerPos)
	{
		Vector3 distanceVector = objPos - playerPos;
		float distance = distanceVector.magnitude;
		return distance;
	}
}

public class ObjectGrabbableState : IObjectStates
{
	private float distance = 0f;
	private float minDistance = 0f;
	public void OnEnterState(ObjectController obj)
	{
		obj.circleCollider.isTrigger = false;
		obj.inRange = true;
		minDistance = obj.transform.localScale.x * 3;
	}
	public void OnUpdateState(ObjectController obj)
	{
		obj.spriteRenderer.color = Color.green;
		distance = CheckPlayerDist(obj.transform.position, obj.player.transform.position);
		if (distance > minDistance)
		{
			obj.SwitchState(obj.idleState);
		}
		Debug.Log(distance);
	}

	public void OnExitState(ObjectController obj)
	{

	}

	public float CheckPlayerDist(Vector3 objPos, Vector3 playerPos)
	{
		Vector3 distanceVector = objPos - playerPos;
		float distance = distanceVector.magnitude;
		return distance;
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
		obj.spriteRenderer.color = Color.blue;
    }

    public void OnExitState(ObjectController obj)
    {

    }
}