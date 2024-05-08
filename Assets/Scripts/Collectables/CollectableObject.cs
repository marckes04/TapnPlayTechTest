using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public bool spend;
    public bool collect;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();    

        if (playerInventory != null )
        {
            if (collect)
            {
                playerInventory.MoneyCollected();
                gameObject.SetActive(false);
            }

            if (spend)
            {
                playerInventory.MoneySpent();
            }
        }
    }
}
