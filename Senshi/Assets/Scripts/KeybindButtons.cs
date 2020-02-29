using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// keybindmenu buttons to change and see current keybinds
/// by Zayarmoe Kyaw
/// </summary>
public class KeybindButtons : MonoBehaviour
{
    [SerializeField] private Text currentKeybind;
    [SerializeField] private KeyCode key;
    [SerializeField] private Toggle wantedKeybind;

    [SerializeField] private KeybindManager.PlayerOption player;
    [SerializeField] private KeybindManager.InputOption keyToBind;
    [SerializeField] private KeyCode newKeybind;

    [SerializeField] private KeybindManager keybinder;

    private void Update()
    {
        DisplayCurrentKeybind();
    }

    public void ChangeKeybind(KeyCode newKey)
    {
        if (wantedKeybind.isOn == true)
        {
            keybinder.DeleteKeybind(key);
            keybinder.ChangeKeybind(player, keyToBind, newKey);
            DisplayCurrentKeybind();
            wantedKeybind.isOn = false;
        }
    }

    private void DisplayCurrentKeybind()
    {
        key = keybinder.GetPlayerKeybinds(player).FirstOrDefault(val => val.Value == keyToBind).Key;
        currentKeybind.text = key.ToString();
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && wantedKeybind.isOn == true)
        {
            newKeybind = e.keyCode;
            ChangeKeybind(newKeybind);
        }
    }
}