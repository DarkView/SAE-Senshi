using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Update()
    {
        ChangeAudio();
        ChangeScreenMode();
    }

    private void ChangeAudio()
    {
        AudioListener.volume = audio.value;
    }

    private void ChangeResolution()
    {

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
        Destroy(this);
    }
}
