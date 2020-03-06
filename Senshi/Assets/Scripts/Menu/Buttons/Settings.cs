using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Buttons for Settings menu 
/// by Zayarmoe 
/// </summary>
public class Settings : MonoBehaviour
{
    /// <summary>
    /// slider object to change the audio volume ; serialized private
    /// </summary>
    [SerializeField] private Slider audio;
    /// <summary>
    /// gameObject containing the settings menu ; serialized private
    /// </summary>
    [SerializeField] private GameObject settingsObject;
    /// <summary>
    /// object containing the controls prefab ; serialized private
    /// </summary>
    [SerializeField] private Object controlsObject;
    /// <summary>
    /// object containing the pause menu ; serialized private
    /// </summary>
    [SerializeField] private Object pauseMenuObject;
    
    /// <summary>
    /// update function called every frame ; calls ChangeAudio() ; private 
    /// </summary>
    private void Update()
    {
        ChangeAudio();
    }

    /// <summary>
    /// method to open the controls screen ; for button ; public 
    /// </summary>
    public void OpenControls()
    {
        Instantiate(controlsObject);
        Destroy(settingsObject);
    }

    /// <summary>
    /// closes the settings screen and opens the pause menu or the main menu depending on the access point to the settings screen ; for button ; public 
    /// </summary>
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
                Instantiate(pauseMenuObject);
                Destroy(settingsObject);
                break;
        }
    }
    
    /// <summary>
    /// method to change the volume of the audio listener to the value of the audio slider ; private 
    /// </summary>
    private void ChangeAudio()
    {
        AudioListener.volume = audio.value;
    }
}

