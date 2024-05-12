using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientChecker : MonoBehaviour
{

    public string _type = "";

    public IngredientChecker(string type)
    {
        _type = type;
    }
    public string CheckType()
    {
        return _type;
    }
}
