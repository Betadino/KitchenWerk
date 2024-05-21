using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    public Sprite[] sprites;
    bool isCooked = false;
    bool isCombined=false;
    bool canCombine=false;
    string type;
    private SpriteRenderer sr;


    Collider2D objRef;
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown() {
        if(canCombine)
        {
            CombinePizza(type, objRef);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        objRef=null;
        if (!isCombined)
        {

            if (other.gameObject.GetComponent<IngredientChecker>())
            {
            objRef=other;
            type = other.gameObject.GetComponent<IngredientChecker>().CheckType();
            canCombine = true;
            }
        }
    }

    void CombinePizza(string type, Collider2D other){
        switch (type)
        {
            case "pepperoni":
                sr.sprite = sprites[1];
                isCombined = true;
                Destroy(other.gameObject);
                break;
            case "mushroom":
                sr.sprite = sprites[2];
                Destroy(other.gameObject);
                isCombined = true;
                break;
            case "bacon":
                sr.sprite = sprites[3];
                Destroy(other.gameObject);
                isCombined = true;
                break;
            default:
                Debug.LogError("The type" + type + " isn't defined");
                break;
        }
    }

}
