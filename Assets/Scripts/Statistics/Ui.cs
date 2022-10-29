using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField] private Statistics statistics;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text moneyTextInMenu;
    [SerializeField] private Slider lvlSlider;
    [SerializeField] private Text levelText;
    private void Start()
    {

        lvlSlider.maxValue = statistics.expNextLvl;
    }

    private void Update()
    {
        lvlSlider.value = statistics.exp;
        levelText.text = "level: " + statistics.level;
        moneyText.text  = statistics.money.ToString() + "$";
        moneyTextInMenu.text  = statistics.money.ToString() + "$";
    }
}
