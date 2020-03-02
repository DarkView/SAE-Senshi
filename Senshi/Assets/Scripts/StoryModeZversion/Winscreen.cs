using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// prints the winscreen used during singleplayer mode
/// by Zayarmoe
/// </summary>
public class Winscreen : MonoBehaviour
{
    [SerializeField] private Text winScreenText;
 
    public void PrintFightWinner(int winner)
    {
        winScreenText.text = (winner == 1) ? "Player 1 wins!" : "Player 2 wins!";
    }
}