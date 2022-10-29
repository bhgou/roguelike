using UnityEngine;

public class Equip : MonoBehaviour
{


    public CellManager item;

    public InventoryCell cell;
    private void Update()
    {
        item = cell.item;

    }

    public void EquipItem()
    {

        if (item.isEquip && EqupSlots._instance.freeSlot < 2 && !SellButton.Button.isSell)
        {
            EqupSlots._instance.freeSlot++;
            Cells.Instance.equipSlots[EqupSlots._instance.freeSlot - 1].item = item;

        }

    }
    public void UndoItem()
    {
        EqupSlots._instance.freeSlot--;
        Cells.Instance.equipSlots[EqupSlots._instance.freeSlot].item = null;

    }

}
