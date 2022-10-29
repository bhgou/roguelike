using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string tag;
    [SerializeField] private GameObject panel;

    public void StartGame()
    {
        SceneTransition.SwitchToScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            panel.SetActive(false);
        }
    }
}
