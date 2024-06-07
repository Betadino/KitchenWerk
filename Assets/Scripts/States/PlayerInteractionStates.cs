using Unity.VisualScripting;
using UnityEngine;


public class PlayerHandsFreeState : IPlayerInteractionStates
{
    public GameObject selectedObject;
    PlayerController _player;
    public void OnEnterState(PlayerController player)
    {
        selectedObject = null;
        _player = player;
    }

    public void OnUpdateState(PlayerController player) 
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckObject();
            if (selectedObject != null)
            {
				player.SwitchInteractionState(player.playerIsPickingState);
            }
        }
	}

    public void OnExitState(PlayerController player)
    {
        player.currentItem = selectedObject;
    }

    public void CheckObject()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject.CompareTag("pickable"))
        {
            GameObject objectHit = hit.collider.gameObject;
            if (objectHit.GetComponent<ObjectController>().inRange == true)
            {
				selectedObject = objectHit;
			}
        }
         if (hit.collider != null && hit.collider.gameObject.CompareTag("crate"))
        {
            GameObject objectHit = hit.collider.gameObject;
            if (objectHit.GetComponent<ObjectController>().inRange == true)
            {
                var prefab = objectHit.GetComponent<IngPrefab>().Prefab;
				selectedObject = GameObject.Instantiate(prefab, _player.gameObject.transform.position , Quaternion.identity);

			}
        }

         if (hit.collider != null && hit.collider.gameObject.CompareTag("oven"))
        {
            GameManager.SetOvenDoor();
        }
    }
}

public class PlayerIsPickingState : IPlayerInteractionStates
{
    public GameObject selectedObject;

    public void OnEnterState(PlayerController player)
    {
        selectedObject = player.currentItem;
        if (selectedObject != null && selectedObject.CompareTag("pickable"))
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

   
}