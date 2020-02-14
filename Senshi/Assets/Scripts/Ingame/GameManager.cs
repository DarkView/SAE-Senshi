using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all things game-related like Input
/// By Nils
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The controller for Player 1
    /// </summary>
    public PlayerController Player1Controller;
    /// <summary>
    /// The controller for Player 2
    /// </summary>
    public PlayerController Player2Controller;

    /// <summary>
    /// Cached keybinds for player 1
    /// </summary>
    private Dictionary<KeyCode, KeybindManager.InputOption> player1Keybinds;
    /// <summary>
    /// Cached keybinds for player 2
    /// </summary>
    private Dictionary<KeyCode, KeybindManager.InputOption> player2Keybinds;

    /// <summary>
    /// The loaded KeybindManager
    /// </summary>
    private KeybindManager input;

    /// <summary>
    /// Load the Keybind Manager and retrieves current keybinds
    /// </summary>
    void Start()
    {
        Time.timeScale = 1;
        input = transform.GetComponent<KeybindManager>();
        player1Keybinds = input.GetPlayerKeybinds(KeybindManager.PlayerOption.Player_1);
        player2Keybinds = input.GetPlayerKeybinds(KeybindManager.PlayerOption.Player_2);
    }

    /// <summary>
    /// Unpauses game and reloads keybinds in case they changed
    /// </summary>
    void Unpause()
    {
        player1Keybinds = input.GetPlayerKeybinds(KeybindManager.PlayerOption.Player_1);
        player2Keybinds = input.GetPlayerKeybinds(KeybindManager.PlayerOption.Player_2);
    }

    /// <summary>
    /// Called multiple times a frame. We check if the event retrieved is applicable to our keybinds
    /// If it is, we execute the necessary action
    /// </summary>
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            if (player1Keybinds.ContainsKey(e.keyCode))
            {
                KeybindManager.InputOption io;
                if (player1Keybinds.TryGetValue(e.keyCode, out io))
                {
                    HandleInput(Player1Controller, io);
                }
                else
                {
                    Debug.Log("Unknown error in retrieving keybinds");
                }
            }
            else
            {
                if (player2Keybinds.ContainsKey(e.keyCode))
                {
                    KeybindManager.InputOption io;
                    if (player2Keybinds.TryGetValue(e.keyCode, out io))
                    {
                        HandleInput(Player2Controller, io);
                    }
                    else
                    {
                        Debug.Log("Unknown error in retrieving keybinds");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Actual action assignment and execution
    /// </summary>
    /// <param name="player">The player that will execute the action</param>
    /// <param name="input">The given input</param>
    private void HandleInput(PlayerController player, KeybindManager.InputOption input)
    {
        switch (input)
        {
            case KeybindManager.InputOption.Left:
                player.MoveLeft();
                break;
            case KeybindManager.InputOption.Right:
                player.MoveRight();
                break;
            case KeybindManager.InputOption.Up:
                player.MoveUp();
                break;
            case KeybindManager.InputOption.Down:
                player.MoveDown();
                break;
            case KeybindManager.InputOption.LPunch:
                player.PunchLeft();
                break;
            case KeybindManager.InputOption.RPunch:
                player.PunchRight();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(input), input, null);
        }
    }
}
