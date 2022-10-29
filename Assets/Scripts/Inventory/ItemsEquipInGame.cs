using UnityEngine;

public class ItemsEquipInGame : MonoBehaviour
{

    [SerializeField] private ItemsIsEquip itemsIsEquip;
    [SerializeField] private Equip[] items;
    public bool clear;
    public void Update()
    {
        itemsIsEquip.item_1 = items[0].item;
        itemsIsEquip.item_2 = items[1].item;
        if (clear)
        {
            items[0].item = null;
            items[1].item = null;
            items[0].gameObject.GetComponent<InventoryCell>().item = null;
            items[1].gameObject.GetComponent<InventoryCell>().item = null;
            EqupSlots.Instance.freeSlot = 0;
        }

   
    }

} 
