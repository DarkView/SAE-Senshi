using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu Buttons a
/// by Zayarmoe 
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// object containing the start scene/fight scene ; serialized private
    /// </summary>
    [SerializeField] private Object startScene;
    /// <summary>
    /// gameObject containing the main menu ; serialized private 
    /// </summary>
    [SerializeField] private GameObject mainMenuObject;
    /// <summary>
    /// gameObject containing the story selection prefab ; serialized private 
    /// </summary>
    [SerializeField] private GameObject storySelectionObject;

    /// <summary>
    /// methods to create the story selections screen ; for button ; public 
    /// </summary>
    public void StartStory()
    {
        Instantiate(storySelectionObject);
        Destroy(mainMenuObject);
    }

    /// <summary>
    /// method to start the singleplayer mode ; for button ; public 
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    /// <summary>
    /// method to create the settings screen ; for button ; public 
    /// </summary>
    public void OpenSettings()
    {
        MenuManager.menuState = 1;
        MenuManager.menuExist = false;
        Destroy(mainMenuObject);
    }

    /// <summary>
    /// method to stop play mode in editor/ close application in build version ; for button ; public 
    /// </summary>
    public void CloseApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}