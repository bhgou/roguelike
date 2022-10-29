using UnityEngine;

public class StatisticManager : MonoBehaviour
{
    public static StatisticManager _manager;
    public static StatisticManager Manager
    {
        get { return _manager; }
    }

    public Statistics statistics;


    private void Awake()
    {
        _manager = this;
    }
    private void Update()
    {
        if (statistics.exp >= statistics.expNextLvl)
        {
            statistics.level++;
            statistics.exp = 0;
            statistics.expNextLvl *= 2;
        }
    }
    public void AddMoney(int money)
    {
        statistics.money += money;
    }
    public void RemoveMoney(int remove)
    {
        statistics.money -= remove;
    }
    public void AddLevel(int lvl)
    {
        statistics.level += lvl;
    }
    public void AddExp(int exp)
    {
        statistics.exp += exp;
    }
}
