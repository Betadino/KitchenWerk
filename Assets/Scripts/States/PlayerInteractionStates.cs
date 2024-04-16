using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerHandsFreeState : IPlayerInteractionStates
{
    public GameObject selectedObject;
    public float distance = 0f;
    public void OnEnterState(PlayerController player)
    {
        selectedObject = null;
    }

    public void OnUpdateState(PlayerController player) 
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckObject();
            if (selectedObject != null)
            {
                distance = CheckDistance(player.gameObject, selectedObject.gameObject);
                if (distance <= 2f)
                {
                    player.SwitchInteractionState(player.playerIsPickingState);
                }
            }
            /*distance = CheckDistance(player.gameObject, selectedObject);
            if (distance <= 2f)
            {
                player.SwitchInteractionState(player.playerIsPickingState);
            }
            else
            {
                Debug.Log("TOO FAR");
            }*/
        }
	}

    public void OnExitState(PlayerController player)
    {

    }

    public float CheckDistance(GameObject player, GameObject obj)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 objPos = new Vector2(obj.transform.position.x, obj.transform.position.y);
        float distance = Vector2.Distance(playerPos, objPos);
        return distance;
    }

    public void CheckObject()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject.tag == "pickable")
        {
            GameObject objectHit = hit.collider.gameObject;
            selectedObject = objectHit;
        }
    }
}

public class PlayerIsPickingState : IPlayerInteractionStates
{
    public GameObject selectedObject;

    public void OnEnterState(PlayerController player)
    {
        CheckObject();
        if (selectedObject != null && selectedObject.tag == "pickable")
        {
            selectedObject.GetComponent<ObjectController>().SwitchState(new ObjectGrabbedState());
        }
    }

    public void OnUpdateState(PlayerController player)
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.SwitchInteractionState(player.playerHandsFreeState);
        }
	}

    public void OnExitState(PlayerController player)
    {
        if (selectedObject != null)
        {
            selectedObject.GetComponent<ObjectController>().SwitchState(new ObjectIdleState());
        }
        selectedObject = null;
    }

    public void CheckObject()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject.tag == "pickable")
        {
            GameObject objectHit = hit.collider.gameObject;
            selectedObject = objectHit;
        }
    }
}