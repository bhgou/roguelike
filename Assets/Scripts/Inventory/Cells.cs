using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cells : MonoBehaviour
{
    public static Cells _instance;
    [SerializeField] private GameObject Cell;
    public List<GameObject> Cells_list;
    public InventoryCell[] equipSlots;
    public int CountCells;
    [SerializeField] private Transform Content;
    public List<int> idList;
    public CellManager[] items;
    public int free_slot_id = 0;
    

    public static Cells Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        
        for (int i = 0; i < CountCells; i++)
        {
            GameObject cell = Instantiate(Cell, Content);
            Cells_list.Add(cell);
            Cells_list[i].GetComponent<InventoryCell>().id_cell = i;
        }
        for (int i = 0; i < CountCells; i++)
        {
            if(PlayerPrefs.GetInt("item" + i) != 0)
            {
                idList.Add(PlayerPrefs.GetInt("item" + i));
                
            }
            
        }
        LoadInventory();
    }
    private void Update()
    {
        for (int i = 0; i <= CountCells; i++)
        {
            PlayerPrefs.SetInt("item" + i, idList[i]);
        }
    }
    private void LoadInventory()
    {
        for (int i = 0; i < idList.Count; i++)
        {
            for (int j = 0; j < items.Length; j++)
            {
                if (idList[i] == items[j].id)
                {
                    AddItem(items[j],false);
                    break;
                }
            }
        }
        
    }
    public void AddItem(CellManager item,bool load)
    {
        
        for (int i = 0; i < Cells_list.Count; i++)
        {
            if (Cells_list[i].GetComponent<InventoryCell>().item == null)
            {
               free_slot_id = Cells_list[i].GetComponent<InventoryCell>().id_cell;
               
            }
        }

       if (Cells_list[free_slot_id].GetComponent<InventoryCell>().item == null)
       {
            for (int i = 0; i < items.Length; i++)
            {
               Cells_list[free_slot_id].GetComponent<InventoryCell>().item = item;

            }
            
        }
        if (load)
        {
            idList.Add(Cells_list[free_slot_id].GetComponent<InventoryCell>().item.id);

        }

        
    }
    public void Remove(CellManager item)
    {
        
        for (int i = 0; i < CountCells; i++)
        {
            if (Cells_list[i].GetComponent<InventoryCell>().item == item)
            {
                idList.Remove(item.id);
                PlayerPrefs.DeleteAll();
                Cells_list[i].GetComponent<InventoryCell>().item = null;
                break;
            }
        }

    }
    
}
