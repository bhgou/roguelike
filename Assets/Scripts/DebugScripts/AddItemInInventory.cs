
using UnityEngine;

public class AddItemInInventory : MonoBehaviour
{
    [SerializeField] private CellManager item_1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Cells.Instance.AddItem(item_1,true);
        }
    }

}
