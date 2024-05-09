using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public  int moneyCollection { get; private set; }

    public UnityEvent<PlayerInventory> onMoneyCollected;
    public UnityEvent<PlayerInventory> onMoneySpent;

    public void MoneyCollected()
    {
        moneyCollection++;
        onMoneyCollected.Invoke(this);
        SpawnerNpc.instance.SpawnCharacters(3);
    }

    public void MoneySpent()
    {
        moneyCollection--;
        onMoneySpent.Invoke(this);
    }



}
