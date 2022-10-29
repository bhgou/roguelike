
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCave : MonoBehaviour
{
    public bool Inventory;
    [SerializeField] private GameObject inventory;

    public void Choose(int i)
    {

        SceneManager.LoadScene(i);
        if (Inventory)
        {
            inventory.SetActive(false);
        }
    }
}
