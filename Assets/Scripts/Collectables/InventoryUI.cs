using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI billText;

    // Start is called before the first frame update
    void Start()
    {
        billText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBillText(PlayerInventory playerInventory)
    {
        billText.text = "MONEY: " + playerInventory.moneyCollection;
    }

}
