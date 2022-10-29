using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    private int armor;
    private int maxHealth;

    [SerializeField] private Text armorText;
    [SerializeField] private Text maxHealthText;

    
    private void LoadStatistic()
    {
        maxHealth =  PlayerStats.Instance.health;
    }
    private void UpdateInfo(string text, int variable, Text ui)
    {
        ui.text = text + variable.ToString();
    }

    private void Update()
    {
        LoadStatistic();
        UpdateInfo("Armor: ", armor, armorText);
        UpdateInfo("Health: ", maxHealth, maxHealthText);
    }
    
   
}
