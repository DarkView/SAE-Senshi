using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

/// <summary>
/// Pause menu buttons
/// by Zayarmoe
/// </summary>
public class Pausemenu : MonoBehaviour
{
    [SerializeField] private Object settingsObject;
    [SerializeField] private Object mainMenuScene;
    [SerializeField] private Object pauseMenuObject;

    private void Update()
    {
        ResumeKey();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenuCaller.paused = false;
        Destroy(pauseMenuObject);
    }

    public void ResumeKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void LoadSettings()
    {
        Instantiate(settingsObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene.name, LoadSceneMode.Single);
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