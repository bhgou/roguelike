using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField] private int amount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StatisticManager.Manager.AddMoney(amount);
        }
    }
}
