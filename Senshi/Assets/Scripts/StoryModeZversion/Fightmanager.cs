using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// checks for winconditions during the fight, resets the fight
/// by Zayarmoe
/// </summary>
public class Fightmanager : MonoBehaviour
{
    /// <summary>
    /// player stats object representing player one ; serialized private 
    /// </summary>
    [SerializeField] private PlayerStats player1;
    /// <summary>
    /// player stats object representing player two ; serialized private 
    /// </summary>
    [SerializeField] private PlayerStats player2;
    /// <summary>
    /// int object representing the starting time of the timer ; serialized private
    /// </summary>
    [SerializeField] private int timer = 120;
    /// <summary>
    /// float object representing the currently passed time in this round ; serialized private 
    /// </summary>
    [SerializeField] private float passedTime;
    /// <summary>
    /// text object representing the text field displaying the timer ; serialized private 
    /// </summary>
    [SerializeField] private Text timerText;

    /// <summary>
    /// gameObject containing the win screen prefab ; serialized private 
    /// </summary>
    [SerializeField] private GameObject winScreen;
    /// <summary>
    /// int value representing the player that wins the current fight ; protected 
    /// </summary>
    protected int Winner;

    /// <summary>
    /// int value representing the amount of time the player won in current fight for player one ; protected 
    /// </summary>
    protected int Player1Wins;
    /// <summary>
    /// int value representing the amount of time the player won in current fight for player two ; protected 
    /// </summary>
    protected int Player2Wins;
    /// <summary>
    /// int value representing the needed amounts of wins to win the fight ; returns 1 in story mode ; returns 3 in singleplayer mode ; protected 
    /// </summary>
    protected int NeededWins
    {
        get
        {
            if (StoryManager.isStoryMode) return 1;
            else return 3;
        }
    }
    /// <summary>
    /// bool value representing whether the fight has finished or not ; protected 
    /// </summary>
    protected bool fightFinished;

    /// <summary>
    /// start function called on instance ; calls InitFight() CheckStoryMode() InitPlayerStats() ; private
    /// </summary>
    private void Start()
    {
        InitFight();
        CheckStoryMode();
        InitPlayerStats();
    }

    /// <summary>
    /// update function called every frame ; calls InitFightConditionChecker() PrintTimer() ; private
    /// </summary>
    private void Update()
    {
        InitFightConditonChecker();
        PrintTimer();
    }

    /// <summary>
    /// method to delete this script if story mode is active ; protected virtual 
    /// </summary>
    protected virtual void CheckStoryMode()
    {
        if (StoryManager.isStoryMode)
            Destroy(this);
    }

    /// <summary>
    /// method to sets the default value for players and fight ; private 
    /// </summary>
    private void InitFight()
    {
        player1.StatReset();
        player2.StatReset();
        passedTime = timer;
        StartCoroutine(CountTimer());
    }

    /// <summary>
    /// method to display the needed amount of wins in current fight in UI ; private
    /// </summary>
    private void InitPlayerStats()
    {
        player1.InitWinCount(NeededWins);
        player2.InitWinCount(NeededWins);
    }

    /// <summary>
    /// method to calling all methods to check if the round or fight is finished ; private 
    /// </summary>
    private void InitFightConditonChecker()
    {
        CheckPlayerDeath();
        CheckTimerFinish();
        CheckFightFinish();
    }

    /// <summary>
    /// method to check the player health to get winner ; private 
    /// </summary>
    private void CheckPlayerDeath()
    {
        if (player1.health > 0 && player2.health > 0)
            return;

        if (player1.health <= 0)
            Player2Wins++;
        else if (player2.health <= 0)
            Player1Wins++;

        RestartFight();
    }

    /// <summary>
    /// method to check if the timer has run out and selects winner with more health ; private 
    /// </summary>
    private void CheckTimerFinish()
    {
        if (passedTime > 0)
            return;

        if (player1.health > player2.health)
            Player1Wins++;
        else
            Player2Wins++;

        RestartFight();
    }

    /// <summary>
    /// method to check if a player has reached the needed amount of wins and prints the win screen ; protected virtual
    /// </summary>
    protected virtual void CheckFightFinish()
    {
        if ((Player1Wins == NeededWins || Player2Wins == NeededWins) && !fightFinished)
        {
            fightFinished = true;
            StopAllCoroutines();
            Time.timeScale = 0;
        }
        else return;

        Winner = (Player1Wins == NeededWins) ? 1 : 2;
        Instantiate(winScreen).GetComponentInChildren<Winscreen>().PrintFightWinner(Winner);
    }

    /// <summary>
    /// IEnumerator waits one second and reduces the timer by one ; private
    /// </summary>
    /// <returns></returns>
    private IEnumerator CountTimer()
    {
        for (var i = 0; i < timer; i++)
        {
            yield return new WaitForSeconds(1f);
            passedTime--;
        }
    }

    /// <summary>
    /// method to display timer on timerText text field ; private 
    /// </summary>
    private void PrintTimer()
    {
        timerText.text = ((int) passedTime).ToString();
    }

    /// <summary>
    /// method to restart the round and initialize the next round ; private 
    /// </summary>
    private void RestartFight()
    {
        StopAllCoroutines();
        player1.PrintWinCount(Player1Wins);
        player2.PrintWinCount(Player2Wins);
        InitFight();
    }
}