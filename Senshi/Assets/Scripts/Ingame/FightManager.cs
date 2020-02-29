using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField] private PlayerStats player1;
    [SerializeField] private PlayerStats player2;
    [SerializeField] private int winsNeeded;
    [SerializeField] private GameObject senshiWin;
    [SerializeField] private GameObject senshiLost;
    [SerializeField] private GameObject mainMenu;
    private int timer = 0;
    private int winCounterPlayer1 = 0;
    private int winCounterPlayer2 = 0;
    private bool storyModeIsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (storyModeIsActive)
        {
            winsNeeded = 1;
        }
        else
        {
            winsNeeded = 3;
        }
        StartCoroutine(TimerUpdater());
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckRoundWin();
        this.CheckFightWin();
        
    }

    private IEnumerator TimerUpdater()
    {
        yield return new WaitForSeconds(1);
        this.timer += 1;
    }

    private void CheckRoundWin()
    {
        if (player1.health <= 0 || player2.health <= 0 || this.timer >= 120)
        {
            this.FindWinner();
            this.ResetFight();
        }
    }

    private void FindWinner()
    {
        if (player1.health > player2.health)
        {
            //info einfügen
            this.RoundWin(1);
        }
        else if (player2.health > player1.health)
        {
            //info einfügen
            this.RoundWin(2);
        }
        else
        {
            //info einfügen
        }
    }

    private void ResetFight()
    {
        player1.transform.position = player1.DefaultPosition;
        player1.health = 100;
        player2.transform.position = player2.DefaultPosition;
        player2.health = 100;
        this.timer = 0;
    }

    private void RoundWin(int roundWinner)
    {
        if (roundWinner == 1)
        {
            winCounterPlayer1 ++;
        }
        else
        {
            winCounterPlayer2 ++;
        }
    }

    private void CheckFightWin()
    {
        if (winCounterPlayer1 == winsNeeded || winCounterPlayer2 == winsNeeded)
            if (winCounterPlayer1 == winsNeeded)
            {
                this.FightWin(1);
            }
            else
            {
                this.FightWin(2);
            }
    }

    private void FightWin(int fightWinner)
    {
        if (storyModeIsActive)
        {
            if (fightWinner == 1)
            {
                Instantiate(senshiWin);
                Time.timeScale = 0;
                Destroy(this);
            }
            else
            {
                Instantiate(senshiLost);
                Time.timeScale = 0;
                Destroy(this);
            }
        }
        else
        {
            //show winner
            Instantiate(mainMenu);
            Time.timeScale = 0;
            Destroy(this);
        }
    }
}
