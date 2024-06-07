using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text orderText;

    public void UpdateOrderText(string orderName)
    {
        orderText.text = "Order: " + orderName;
    }

    public void ClearOrderText()
    {
        orderText.text = "";
    }
}
