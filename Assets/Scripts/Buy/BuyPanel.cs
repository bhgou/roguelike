using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    public static BuyPanel instance;
    public static BuyPanel Instance
    {
        get { return instance; }
    }

    public CellManager item;
    private int price;
    [SerializeField] private Image icon;
    [SerializeField] private Text priceText;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        icon.sprite = item.icon;
        price = item.price * 2;
        priceText.text = "price: " + price.ToString();
    }

    public void Buy()
    {
        if (StatisticManager.Manager.statistics.money >= item.price * 2)
        {
            Cells.Instance.AddItem(item, true);
            StatisticManager.Manager.RemoveMoney(item.price * 2);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
