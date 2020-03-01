using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Buttons for Settings menu 
/// by Zayarmoe Kyaw
/// </summary>
public class Settings : MonoBehaviour
{
    [SerializeField] private Slider audio;
    [SerializeField] private Dropdown resolution;
    [SerializeField] private Dropdown screenMode;
    [SerializeField] private GameObject settingsObject;
    [SerializeField] private Object controlsObject;
    [SerializeField] private Object pausemenuObject;
    
    private void Update()
    {
        ChangeAudio();
        ChangeScreenMode();
    }

    public void OpenControls()
    {
        Instantiate(controlsObject);
        Destroy(settingsObject);
    }

    private void ChangeAudio()
    {
        AudioListener.volume = audio.value;
    }

    private void ChangeScreenMode()
    {
        switch (screenMode.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }

    public void CloseScreen()
    {
        switch (PauseMenuCaller.paused)
        {
            case false:
                MenuManager.menuState = 2;
                MenuManager.menuExist = false;
                Destroy(settingsObject);
                break;
            case true:
                Instantiate(pausemenuObject);
                Destroy(settingsObject);
                break;
        }
    }
}

