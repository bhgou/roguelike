using UnityEngine;

public class RewardItem : MonoBehaviour
{
    [SerializeField] private DropItem drop;
    [SerializeField] private CellManager item;
    bool take = true;
    private void Update()
    {
        if(take)
        {
            item = drop.item;
            Cells.Instance.AddItem(item, true);
            drop.item = null;
            take = false; 
        }
       
    }
}
