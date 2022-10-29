using UnityEngine;

[CreateAssetMenu(fileName = "item")]

public class CellManager : ScriptableObject
{
    public int id;
    public string name;
    public bool isEquip;
    public bool isHill;
    public int price;
    [Header("Visual")]
    public Sprite icon;
}
