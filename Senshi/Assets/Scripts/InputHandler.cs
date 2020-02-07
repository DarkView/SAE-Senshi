using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// Basic inputhandling and custom keybinds
/// By Nils
/// </summary>
public class InputHandler : MonoBehaviour
{

    private string cfgFolderBase = "./cfg/";
    private Dictionary<InputOption, KeyCode> keybinds = new Dictionary<InputOption, KeyCode>();

    /// <summary>
    /// Load or create all keybinds
    /// </summary>
    void Awake()
    {

        if (!Directory.Exists(cfgFolderBase))
        {
            Directory.CreateDirectory(cfgFolderBase);
        }

        if (File.Exists(cfgFolderBase + "keys.json"))
        {
            keybinds = (Dictionary<InputOption, KeyCode>) JsonConvert.DeserializeObject(cfgFolderBase + "keys.json");
        }
        else
        {
            // Default Keybinds
            // Player 1
            keybinds.Add(InputOption.P1_Left, KeyCode.A);
            keybinds.Add(InputOption.P1_Right, KeyCode.D);
            keybinds.Add(InputOption.P1_Up, KeyCode.W);
            keybinds.Add(InputOption.P1_Down, KeyCode.S);

            keybinds.Add(InputOption.P1_LPunch, KeyCode.R);
            keybinds.Add(InputOption.P1_RPunch, KeyCode.T);

            // Player 2  InputOption.  
            keybinds.Add(InputOption.P2_Left, KeyCode.J);
            keybinds.Add(InputOption.P2_Right, KeyCode.L);
            keybinds.Add(InputOption.P2_Up, KeyCode.I);
            keybinds.Add(InputOption.P2_Down, KeyCode.K);

            keybinds.Add(InputOption.P2_LPunch, KeyCode.Keypad4);
            keybinds.Add(InputOption.P2_RPunch, KeyCode.Keypad5);
            
            StreamWriter sw = File.CreateText(cfgFolderBase + "keys.json");
            sw.Write(JsonConvert.SerializeObject(keybinds));
            sw.Close();
        }
        
    }

    public bool ChangeKeybind(InputOption bind, KeyCode key)
    {
        foreach (KeyCode kc in keybinds.Values)
        {
            if (kc == key)
            {
                throw new ArgumentException("That key is already bound!");
            }
        }

        keybinds[bind] = key;
        return true;
    }

    /*
    void Update()
    {
        
    }
    */

    public enum InputOption
    {
        P1_Left = 0,
        P1_Right,
        P1_Up,
        P1_Down,
        P1_LPunch,
        P1_RPunch,
        P2_Left,
        P2_Right,
        P2_Up,
        P2_Down,
        P2_LPunch,
        P2_RPunch,
    }

}