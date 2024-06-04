using Unity.VisualScripting;
using UnityEngine;

public class DragAndRotate : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

     private Vector3 curPosition;
    void OnMouseDown()
    {
       
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

       
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
      
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(0, 0, 90);
        }

        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Placeholder"))
        {
            gameObject.transform.SetParent(collider.transform);
            transform.position = collider.gameObject.transform.position;
        }
    }
}
