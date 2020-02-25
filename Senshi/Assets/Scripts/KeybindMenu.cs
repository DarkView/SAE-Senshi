using UnityEngine;

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