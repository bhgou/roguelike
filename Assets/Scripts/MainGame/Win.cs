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
    public int countEnemys;
    [SerializeField] private GameObject panel;
    [SerializeField] private CellManager[] dropItems;
    [SerializeField] private DropItem drop;
    [SerializeField] private Image icon;
    [SerializeField] private Text dropText;
    public  List<GameObject> Enemys;
    private void Start()
    {
        panel.SetActive(false);


        Enemys.Add(GameObject.FindGameObjectWithTag("Enemy"));
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
       


        if (countEnemys == 0)
        {
            countEnemys = -1;
            panel.SetActive(true);
            dropItem();
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
