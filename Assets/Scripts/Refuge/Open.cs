using UnityEngine;

public class Open: MonoBehaviour
{
    [SerializeField] private GameObject buttonOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonOpen.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttonOpen.SetActive(false);
        }
    }
}
