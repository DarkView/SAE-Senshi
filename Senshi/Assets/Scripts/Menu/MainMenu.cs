using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu Buttons and input loops
/// by Zayarmoe
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Object startScene;
    [SerializeField] private Object settingsScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(startScene.name, LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        MenuManager.menuState = 1;
        Destroy(this);
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