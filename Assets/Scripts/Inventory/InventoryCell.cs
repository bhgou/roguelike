using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] Sprite mainSprite;
    [SerializeField] private Cells cells;
    
    public CellManager item;
    public int id_cell;
    private void Start()
    {
       
        cells = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Cells>();
    }
    private void Update()
    {
        if(item && item.icon)
        {
            icon.sprite = item.icon;
        }
        if(item == null)
        {
            icon.sprite = mainSprite;
        }
        
    }
    public void Remove()
    {
        if(item != null){
            for (int i = 0; i < Cells.Instance.idList.Count; i++)
            {
                if (Cells.Instance.idList[i] == item.id)
                {
                    PlayerPrefs.DeleteKey("item" + i);
                    Cells.Instance.idList.RemoveAt(i);
                }
            }
        }
        
        item = null;
    }
    

}
