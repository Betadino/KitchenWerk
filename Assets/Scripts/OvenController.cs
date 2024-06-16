
using UnityEngine;


public class OvenController : MonoBehaviour
{
    public Sprite[] ovenSprite;
    public  bool doorOpen;
    
    public bool isCooking, isPizzaInside, isCooked;
    
    public OvenStatesHandler ovenStatesHandler = new();

    public GameObject currentPizza;
    void Start()
    {   
        isPizzaInside = false;
        ovenStatesHandler = new();
        GameManager.E_oven += HandleOvenDoor;
        ovenStatesHandler.SetState(new OvenClosedState(), this);
    }
    
     void OnDisable() {
        GameManager.E_oven -= HandleOvenDoor;
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

    void OnTriggerEnter2D(Collider2D other) {
    
        if(other.gameObject.GetComponent<FoodItem>().name.StartsWith("Raw"))
        {
            isCooked = false;
            currentPizza = other.gameObject;
            isPizzaInside=true;
            //Debug.Log(isPizzaInside);
        }
    }

     void OnTriggerExit2D(Collider2D other) 
     {
            isPizzaInside=false;  
            //Debug.Log(isPizzaInside);
     }
}
