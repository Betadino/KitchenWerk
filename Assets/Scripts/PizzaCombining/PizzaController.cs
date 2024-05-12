using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    public Sprite[] sprites;
    bool isCooked = false;
    bool isCombined=false;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!isCombined)
        {

            if (other.gameObject.GetComponent<IngredientChecker>())
            {
            string type = other.gameObject.GetComponent<IngredientChecker>().CheckType();

                switch (type)
                {
                    case "pepperoni":
                        sr.sprite = sprites[1];
                        Destroy(other.gameObject);
                        break;
                    case "mushroom":
                        sr.sprite = sprites[2];
                        Destroy(other.gameObject);
                        break;
                    case "bacon":
                        sr.sprite = sprites[3];
                        Destroy(other.gameObject);
                        break;
                    default:
                        Debug.LogError("The type" + type + " isn't defined");
                        break;
                }

            }
        }
    }
}
