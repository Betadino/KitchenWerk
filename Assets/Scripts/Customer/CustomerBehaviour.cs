
using UnityEngine;


public class CustomerBehaviour : MonoBehaviour
{

    [Header("This is set on Customer Spawner")]
    public Transform  orderPoint, leavePoint;

    bool orderFullfilled = false;
    public Rigidbody2D rb;
    void MoveToTarget(Transform waypoint)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoint.position, 2 * Time.deltaTime);
        var lookDirection = new Vector2(waypoint.transform.position.x - rb.position.x, waypoint.transform.position.y - rb.position.y);
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg-90f;
        rb.rotation = lookAngle;
        
    }

    void CheckDistanceToDestroy()
    {
        float dist = Vector3.Distance(gameObject.transform.position, leavePoint.position);
        if (dist < 0.2f)
        {
            Destroy(gameObject);
        }
    }

    

    void CheckDistanceDeployOrder()
    {
        float dist = Vector3.Distance(gameObject.transform.position, orderPoint.position);
        if (dist < 0.2f)
        {
            OrderGenerator.GenerateOrder();
        }
    }

    void setFullfillState()
    {
        orderFullfilled = true;
    }
    void Start()
    {
        GameManager.E_orderDelivered+=setFullfillState;
    }

    void OnDestroy ()
    {
        GameManager.E_orderDelivered-=setFullfillState;

    }
    // Update is called once per frame
    void Update()
    {
        if(!orderFullfilled)
        {
            MoveToTarget(orderPoint);
            CheckDistanceDeployOrder();

        } else {

            MoveToTarget(leavePoint);
            CheckDistanceToDestroy();
        }
    }
}
