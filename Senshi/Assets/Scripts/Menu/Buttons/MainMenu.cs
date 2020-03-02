using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu Buttons and input loops
/// by Zayarmoe Kyaw
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private Object startScene;
    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject storySelectionObject;

    public void StartStory()
    {
        Instantiate(storySelectionObject);
        Destroy(mainMenuObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        MenuManager.menuState = 1;
        MenuManager.menuExist = false;
        Destroy(mainMenuObject);
    }

    public void CloseApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}