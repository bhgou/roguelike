using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellItem : MonoBehaviour
{
    
    public static SellItem _sell;
    public static SellItem Sell
    {
        get { return _sell; }
    }
    public CellManager item;
    [SerializeField] private Image icon;
    [SerializeField] private Text price;
    [SerializeField] private ItemsEquipInGame itemsEquipInGame;

    private void Awake()
    {
        _sell = this;
    }


    private void Update()
    {
        
       if(item != null)
        {
            icon.sprite = item.icon;
            price.text = "Sell: "  + item.price.ToString();
        }
       
    }
    public void Exit()
    {
        itemsEquipInGame.clear = false;
    }
    public void Sellitem()
    {
        itemsEquipInGame.clear = true;

        for (int i = 0; i < Cells.Instance.CountCells; i++)
        {
            if (Cells.Instance.Cells_list[i].GetComponent<InventoryCell>().item == item)
            {
                
                StatisticManager.Manager.AddMoney(item.price);
                Cells.Instance.Remove(item);
                break;
            }
  
        }
       
    }
}
