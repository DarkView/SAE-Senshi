using UnityEngine;

/// <summary>
/// keybind menu specific buttons
/// by Zayarmoe Kyaw
/// </summary>
public class KeybindMenu : MonoBehaviour
{
    /// <summary>
    /// object containing the settings prefab ; serialized private 
    /// </summary>
    [SerializeField] private Object settingsMenu;
    /// <summary>
    /// object containing the key bind menu ; serialized private 
    /// </summary>
    [SerializeField] private Object keybindMenuObject;

    /// <summary>
    /// method to close the controls/key binds menu ; for button ; public 
    /// </summary>
    public void CloseControls()
    {
        Instantiate(settingsMenu);
        Destroy(keybindMenuObject);
    }
}