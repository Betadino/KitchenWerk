using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<IngredientChecker>())
        {
        string type = other.gameObject.GetComponent<IngredientChecker>().CheckType();
        if (type == "pepperoni") 
        {
            sr.sprite = sprites[1];
            Destroy(other.gameObject);
        }
        }
    }
}
