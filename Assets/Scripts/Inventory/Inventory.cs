using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject Inventory_menu;
    
    
    private void Update()
    {
        DontDestroyOnLoad(Inventory_menu);
       
    }
}
