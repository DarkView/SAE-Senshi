using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// checks for winconditions during the fight, resets the fight
/// by Zayarmoe
/// </summary>
public class Fightmanager : MonoBehaviour
{
    [SerializeField] private PlayerStats player1;
    [SerializeField] private PlayerStats player2;
    [SerializeField] private int timer = 120;
    [SerializeField] private float passedTime;
    [SerializeField] private Text timerText;

    protected int Player1Wins;
    protected int Player2Wins;
    [SerializeField] protected int NeededWins
    {
        get
        {
            if (StoryManager.isStoryMode) return 1;
            else return 3;
        }
    }
    protected bool fightFinished;

    protected int Winner;
    [SerializeField] private GameObject winScreen;

    protected virtual void Start()
    {
        InitFight();
        CheckStoryMode();
        InitPlayerStats();
    }

    private void Update()
    {
        InitFightConditonChecker();
        PrintTimer();
    }

    protected virtual void CheckStoryMode()
    {
        if (StoryManager.isStoryMode)
            Destroy(this);
    }

    protected virtual void InitFight()
    {
        player1.StatReset();
        player2.StatReset();
        passedTime = timer;
        StartCoroutine(CountTimer());
    }

    private void InitPlayerStats()
    {
        player1.InitWinCount(NeededWins);
        player2.InitWinCount(NeededWins);
    }

    private void InitFightConditonChecker()
    {
        CheckPlayerDeath();
        CheckTimerFinish();
        CheckFightFinish();
    }

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

    private IEnumerator CountTimer()
    {
        for (var i = 0; i < timer; i++)
        {
            yield return new WaitForSeconds(1f);
            passedTime--;
            
        }
    }

    private void PrintTimer()
    {
        timerText.text = ((int) passedTime).ToString();
    }

    private void RestartFight()
    {
        StopAllCoroutines();
        player1.PrintWinCount(Player1Wins);
        player2.PrintWinCount(Player2Wins);
        InitFight();
    }
}