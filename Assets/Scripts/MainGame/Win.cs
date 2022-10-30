using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Win : MonoBehaviour
{
    public static Win instance;
    public static Win Instance
    {
        get { return instance; }
    }
    [SerializeField] private GameObject panel;
    [SerializeField] private CellManager[] dropItems;
    [SerializeField] private DropItem drop;
    [SerializeField] private Image icon;
    [SerializeField] private Text dropText;
    public  List<GameObject> Enemys;
    bool giveItem = false;
    private void Start()
    {
        panel.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(drop.item != null)
        {
            icon.sprite = drop.item.icon;
            dropText.text = drop.name;
        }
        for (int i = 0; i < Enemys.Count; i++)
        {
            if (Enemys[i] == null) { Enemys.RemoveAt(i); }
        }
       
    }
    private void LateUpdate()
    {
        if (Enemys.Count == 0 && !giveItem)
        {
            panel.SetActive(true);
            dropItem();
            giveItem = true;
        }
    }
    private void dropItem()
    {
        drop.item = dropItems[Random.Range(0, dropItems.Length)];
    }
    public void Reward()
    {
        StatisticManager.Manager.AddExp(Random.Range(1, 3));
        SceneManager.LoadScene("Refuge");
        
    }
}
