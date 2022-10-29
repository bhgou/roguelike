using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour
{
    public static HotBar _weapons;
    public static HotBar Weapon { get { return _weapons; } }


    [SerializeField] private Image[] icon;
    [SerializeField] private ItemsIsEquip items;
    [SerializeField] private Sprite mainSprite;
    [SerializeField] private Weapon[] weaponsInGame;

    private void Awake()
    {
        _weapons = this;
    }

    private void Update()
    {
        if (items.item_2 != null)
        {
            icon[1].sprite = items.item_2.icon;
        }
        if (items.item_1 != null)
        {
            icon[0].sprite = items.item_1.icon;
        }


        if (items.item_2 == null)
        {
            icon[1].sprite = mainSprite;
        }
        if (items.item_1 == null)
        {
            icon[0].sprite = mainSprite;
        }
        for (int i = 0; i < weaponsInGame.Length; i++)
        {
            if (items.item_1 == null && items.item_2 == null)
            {
                weaponsInGame[i].gameObject.SetActive(false);
            }

        }

    }

    public void TakeItemCell_1()
    {
        for (int i = 0; i < weaponsInGame.Length; i++)
        {
            weaponsInGame[i].gameObject.SetActive(false);
            if (items.item_1.id == weaponsInGame[i].id)
            {
                weaponsInGame[i].gameObject.SetActive(true);
            }
        }

    }
    public void TakeItemCell_2()
    {
        for (int i = 0; i < weaponsInGame.Length; i++)
        {
            weaponsInGame[i].gameObject.SetActive(false);
            if (items.item_2.id == weaponsInGame[i].id)
            {
                weaponsInGame[i].gameObject.SetActive(true);
            }

        }

    }
}
