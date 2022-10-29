using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator m_Animator;
    AsyncOperation loadSceneOperation;
    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;

    public static void SwitchToScene(string sceneName)
    {
        instance.m_Animator.SetTrigger("loadingStart");

        instance.loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        instance.loadSceneOperation.allowSceneActivation = false;
    }
    private void Start()
    {
        instance = this;

        m_Animator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation) m_Animator.SetTrigger("loadingEnd");
    }
    public void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;
        instance.loadSceneOperation.allowSceneActivation = true;
    }
}
