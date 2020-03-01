using System.Collections;
using UnityEngine;

/// <summary>
/// checks for winconditions during the fight, resets the fight
/// by Zayarmoe
/// </summary>
public class Fightmanager : MonoBehaviour
{
    [SerializeField] private PlayerStats player1;
    [SerializeField] private PlayerStats player2;
    [SerializeField] private int timer = 120;
    [SerializeField] private int passedTime;

    protected int _player1Wins;
    protected int _player2Wins;
    [SerializeField] protected int neededWins;

    protected int _winner;
    [SerializeField] private GameObject winScreen;

    protected virtual void Start()
    {
        InitFight();
        CheckStoryMode();
    }

    private void Update()
    {
        InitFightConditonChecker();
    }

    protected virtual void CheckStoryMode()
    {
        if (StoryManagerZ.isStoryMode)
            Destroy(this);
    }

    protected virtual void InitFight()
    {
        player1.SetDefaultPosition();
        player2.SetDefaultPosition();
        neededWins = 3;
        passedTime = timer;
        StartCoroutine(CountTimer());
    }

    private void InitFightConditonChecker()
    {
        CheckPlayerDeath();
        CheckTimerFinish();
        CheckFightFinish();
    }

    private void CheckPlayerDeath()
    {
        if (player1.health > 0 && player1.health > 0)
            return;

        if (player1.health < 0)
            _player2Wins++;
        else if (player2.health < 0)
            _player1Wins++;

        RestartFight();
    }

    private void CheckTimerFinish()
    {
        if (passedTime > 0)
            return;

        if (player1.health > player2.health)
            _player1Wins++;
        else
            _player2Wins++;

        RestartFight();
    }

    protected virtual void CheckFightFinish()
    {
        if (_player1Wins == neededWins || _player2Wins == neededWins)
            Instantiate(winScreen);
        else return;

        _winner = (_player1Wins == neededWins) ? 1 : 2;
        winScreen.GetComponent<Winscreen>().PrintFightWinner(_winner);
    }

    private IEnumerator CountTimer()
    {
        for (var i = 0; i < timer; i++)
        {
            passedTime--;
            yield return new WaitForSeconds(1);
        }
    }

    private void RestartFight()
    {
        StopCoroutine(CountTimer());
        InitFight();
    }
}