using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItem : MonoBehaviour
{
    public void Pressed()
    {
        SellItem.Sell.item =  GetComponent<InventoryCell>().item;
    }

    
}
