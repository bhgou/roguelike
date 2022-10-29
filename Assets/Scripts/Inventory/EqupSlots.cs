using UnityEngine;

public class EqupSlots : MonoBehaviour
{
    public int freeSlot;
    private int slots = 2;
    public static EqupSlots _instance;
    public static EqupSlots Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        _instance = this;
    }
    private void Update()
    {
        if (freeSlot > slots)
        {
            freeSlot = slots;
        }
        if (freeSlot < 0)
        {
            freeSlot = 0;
        }

    }
}
