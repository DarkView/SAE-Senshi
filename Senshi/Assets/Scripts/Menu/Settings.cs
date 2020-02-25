using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SettingsButtons
/// by Zayarmoe
/// </summary>
public class Settings : MonoBehaviour
{
    [SerializeField] private Slider audio;
    [SerializeField] private Dropdown resolution;
    [SerializeField] private Dropdown screenMode;
    [SerializeField] private GameObject settingsObject;
    [SerializeField] private Object controlsObject;

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
        MenuManager.menuState = 2;
        MenuManager.menuExist = false;
        Destroy(settingsObject);
    }
}
