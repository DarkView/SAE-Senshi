using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// methods used by buttons in pause menu
/// by Zayarmoe 
/// </summary>
public class Pausemenu : MonoBehaviour
{
    /// <summary>
    /// object containing the settings prefab ; serialized private
    /// </summary>
    [SerializeField] private Object settingsObject;
    /// <summary>
    /// object containing the main menu scene ; serialized private
    /// </summary>
    [SerializeField] private Object mainMenuScene;
    /// <summary>
    /// object containing the pause menu gameObject ; serialized private
    /// </summary>
    [SerializeField] private Object pauseMenuObject;

    /// <summary>
    /// update function called every frame ; calls ResumeKey() ; private
    /// </summary>
    private void Update()
    {
        ResumeKey();
    }

    /// <summary>
    /// method to close the pause menu and resume ; for button ; public 
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenuCaller.paused = false;
        Destroy(pauseMenuObject);
    }

    /// <summary>
    /// method to open the pause menu by pressing the escape button ; private 
    /// </summary>
    private void ResumeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    /// <summary>
    /// method to open the settings screen ; for button ; public 
    /// </summary>
    public void LoadSettings()
    {
        Instantiate(settingsObject);
        Destroy(pauseMenuObject);
    }

    /// <summary>
    /// method to open the main menu scene ; for button ; public 
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
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