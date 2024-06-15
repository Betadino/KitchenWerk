
using UnityEngine;


public class CustomerBehaviour : MonoBehaviour
{

    public Transform  orderPoint, leavePoint;

    bool orderFullfilled = false;

    //collider check recipe and turn bool to true
    
    void MoveToTarget(Transform waypoint)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoint.position, 2 * Time.deltaTime);
        gameObject.transform.LookAt(waypoint);
    }

    void CheckDistance()
    {
        float dist = Vector3.Distance(gameObject.transform.position, leavePoint.position);
        if (dist < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!orderFullfilled)
        {
            MoveToTarget(orderPoint);

        } else {

            MoveToTarget(leavePoint);
            CheckDistance();
        }

        
    }
}
