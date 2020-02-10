using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu Buttons and input loops
/// by Zayarmoe
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Object startScene;
    [SerializeField] private Object settingsScene;

    public void StartGame()
    {
        SceneManager.LoadScene(startScene.name, LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(settingsScene.name, LoadSceneMode.Additive);
    }

    public void closeApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}