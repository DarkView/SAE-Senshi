using UnityEngine;

/// <summary>
/// keybind menu specific buttons
/// by Zayarmoe Kyaw
/// </summary>
public class KeybindMenu : MonoBehaviour
{
    [SerializeField] private Object settingsMenu;
    [SerializeField] private Object keybindMenuObject;

    public void CloseControls()
    {
        Instantiate(settingsMenu);
        Destroy(keybindMenuObject);
    }
}