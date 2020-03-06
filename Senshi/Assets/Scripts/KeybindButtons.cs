using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// keybind menu buttons to change and see current keybinds
/// by Zayarmoe 
/// </summary>
public class KeybindButtons : MonoBehaviour
{
    /// <summary>
    /// text object containing the text field displaying the current key bind for selected InputOption ; serialized private 
    /// </summary>
    [SerializeField] private Text currentKeybind;
    /// <summary>
    /// keycode object containing the currently bound key to selected InputOption ; serialized private 
    /// </summary>
    [SerializeField] private KeyCode currentKey;

    /// <summary>
    /// toggle object to toggle changing the key bind ; serialized private 
    /// </summary>
    [SerializeField] private Toggle wantedKeybind;
    /// <summary>
    /// keycode object to change current key bind to ; serialized private 
    /// </summary>
    [SerializeField] private KeyCode newKeybind;

    /// <summary>
    /// PlayerOption representing which players key bind are used/changed ; serialized private 
    /// </summary>
    [SerializeField] private KeybindManager.PlayerOption player;
    /// <summary>
    /// InputOption representing which player actions key bind is used/changed ; serialized private 
    /// </summary>
    [SerializeField] private KeybindManager.InputOption keyToBind;

    /// <summary>
    /// keybindManager object to use methods to change and display key binds ; serialized private 
    /// </summary>
    [SerializeField] private KeybindManager keybinder;

    /// <summary>
    /// update function called every frame ; calls DisplayCurrentKeybind ; private 
    /// </summary>
    private void Update()
    {
        DisplayCurrentKeybind();
    }

    /// <summary>
    /// method to change currently bound key depending on player and keyToBind into newKey ; public 
    /// </summary>
    /// <param name="newKey">new key code to change currently bound key into</param>
    public void ChangeKeybind(KeyCode newKey)
    {
        if (wantedKeybind.isOn)
        {
            keybinder.DeleteKeybind(currentKey);
            keybinder.ChangeKeybind(player, keyToBind, newKey);
            DisplayCurrentKeybind();
            wantedKeybind.isOn = false;
        }
    }

    /// <summary>
    /// method to display currently bound key to Unity UI ; private 
    /// </summary>
    private void DisplayCurrentKeybind()
    {
        currentKey = keybinder.GetPlayerKeybinds(player).FirstOrDefault(val => val.Value == keyToBind).Key;
        currentKeybind.text = currentKey.ToString();
    }

    /// <summary>
    /// OnGUI function called every frame ; checks what key is pressed to change currentKey into pressed key ; private 
    /// </summary>
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && wantedKeybind.isOn)
        {
            newKeybind = e.keyCode;
            ChangeKeybind(newKeybind);
        }
    }
}