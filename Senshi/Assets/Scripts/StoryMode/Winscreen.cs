using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// prints the winscreen used during singleplayer mode
/// by Zayarmoe
/// </summary>
public class Winscreen : MonoBehaviour
{
    /// <summary>
    /// text object containing the text field used in the winscreen prefab ; serialized private 
    /// </summary>
    [SerializeField] private Text winScreenText;
 
    /// <summary>
    /// method to print the text in the win screen depending on winner ; public 
    /// </summary>
    /// <param name="winner">indicator which player won</param>
    public void PrintFightWinner(int winner)
    {
        winScreenText.text = (winner == 1) ? "Player 1 wins!" : "Player 2 wins!";
    }
}