using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    private Image icon;
    [SerializeField] CellManager item;
    private void Start()
    {
        icon = GetComponent<Image>();
        icon.sprite = item.icon;
    }
    public void ChooseItem()
    {
        BuyPanel.Instance.item = item;
    }
}
