using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Basic inputhandling and custom keybinds
/// It is advised to delete the `cfg` folder when changing anything in here
/// By Nils
/// </summary>
public class KeybindManager : MonoBehaviour
{

    private const string CFG_FOLDER = "./cfg/";
    private const string KEYS_CFG = "keys.json";

    private Keybindings keybinds;

    /// <summary>
    /// Load or create all keybinds
    /// </summary>
    private void Awake()
    {

        if (!Directory.Exists(CFG_FOLDER))
        {
            Debug.Log("No config folder, creating...");
            Directory.CreateDirectory(CFG_FOLDER);
        }

        if (File.Exists(CFG_FOLDER + KEYS_CFG))
        {
            keybinds = JsonConvert.DeserializeObject<Keybindings>(File.ReadAllText(CFG_FOLDER + KEYS_CFG));
        }
        else
        {
            Debug.Log("No keys file, creating...");
            LoadDefaultKeybinds();
            SaveKeybindsToFile();
        }

    }

    /// <summary>
    /// Loads all default keybinds into the Dictionary
    /// </summary>
    private void LoadDefaultKeybinds()
    {
        keybinds = new Keybindings();
        // Player 1
        keybinds.player1.Add(KeyCode.A, InputOption.Left);
        keybinds.player1.Add(KeyCode.D, InputOption.Right);
        keybinds.player1.Add(KeyCode.W, InputOption.Up);
        keybinds.player1.Add(KeyCode.S, InputOption.Down);

        keybinds.player1.Add(KeyCode.R, InputOption.LPunch);
        keybinds.player1.Add(KeyCode.T, InputOption.RPunch);

        // Player 2  InputOption.
        keybinds.player2.Add(KeyCode.J, InputOption.Left);
        keybinds.player2.Add(KeyCode.L, InputOption.Right);
        keybinds.player2.Add(KeyCode.I, InputOption.Up);
        keybinds.player2.Add(KeyCode.K, InputOption.Down);

        keybinds.player2.Add(KeyCode.Keypad4, InputOption.LPunch);
        keybinds.player2.Add(KeyCode.Keypad5, InputOption.RPunch);
    }

    /// <summary>
    /// Changes a keybind if the button being assigned isnt already assigned
    /// </summary>
    /// <param name="bind">The InputOption to bind</param>
    /// <param name="key">The key we want to assign to the InputOption</param>
    /// <returns></returns>
    public bool ChangeKeybind(PlayerOption pl, InputOption bind, KeyCode key)
    {
        List<KeyCode> allValues = new List<KeyCode>();
        allValues.AddRange(keybinds.player1.Keys);
        allValues.AddRange(keybinds.player2.Keys);

        foreach (KeyCode kc in allValues)
        {
            if (kc == key)
            {
                throw new ArgumentException("That key is already bound!");
            }
        }
        allValues = null;

        if (pl == PlayerOption.Player_1)
        {
            keybinds.player1[key] = bind;
        }
        else
        {
            keybinds.player2[key] = bind;
        }

        SaveKeybindsToFile();
        return true;
    }

    /// <summary>
    /// Deletes a registered keybind
    /// </summary>
    /// <param name="key">The key to delete</param>
    public void DeleteKeybind(KeyCode key)
    {
        if (keybinds.player1.ContainsKey(key))
        {
            keybinds.player1.Remove(key);
        }
        else
        {
            if (keybinds.player2.ContainsKey(key))
            {
                keybinds.player2.Remove(key);
            }
            else
            {
                throw new ArgumentException("Invalid key! Not assigned on that user");
            }
        }
    }

    /// <summary>
    /// Saves the current keybinds to the keys.json file
    /// </summary>
    private void SaveKeybindsToFile()
    {
        StreamWriter sw = File.CreateText(CFG_FOLDER + KEYS_CFG);
        sw.Write(JsonConvert.SerializeObject(keybinds, Formatting.Indented));
        sw.Close();
    }

    public Dictionary<KeyCode, InputOption> GetPlayerKeybinds(PlayerOption player)
    {
        if (player == PlayerOption.Player_1)
        {
            return keybinds.player1;
        }
        else
        {
            return keybinds.player2;
        }

        throw new ApplicationException("Unable to retrieve Keybinds");
    }

    /// <summary>
    /// Wrapper class for both player keybinding dicts
    /// </summary>
    private class Keybindings
    {
        public Dictionary<KeyCode, InputOption> player1 = new Dictionary<KeyCode, InputOption>();
        public Dictionary<KeyCode, InputOption> player2 = new Dictionary<KeyCode, InputOption>();
    }

    /// <summary>
    /// Enum specifying the different options available for input
    /// </summary>
    public enum InputOption
    {
        Left = 0,
        Right,
        Up,
        Down,
        LPunch,
        RPunch,
    }

    /// <summary>
    /// Simple enum to avoid having to use ints for selecting player
    /// </summary>
    public enum PlayerOption
    {
        Player_1 = 1,
        Player_2 = 2,
    }

}