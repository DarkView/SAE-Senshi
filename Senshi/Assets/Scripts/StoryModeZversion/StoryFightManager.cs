using UnityEngine;

/// <summary>
/// alternate fightmanager used for storymode
/// by Zayarmoe
/// </summary>
public class StoryFightManager : Fightmanager
{
    [SerializeField] private Object continueScreen;
    [SerializeField] private Object gamOverScreen;

    protected override void CheckStoryMode()
    {
        if (!StoryManager.isStoryMode)
            Destroy(this);
    }

    protected override void InitFight()
    {
        base.InitFight();
    }

    protected override void CheckFightFinish()
    {
        if (Player1Wins != NeededWins || Player2Wins != NeededWins)
            return;

        Winner = (Player1Wins == NeededWins) ? 1 : 2;

        switch (Winner)
        {
            case 1:
                Instantiate(continueScreen);
                break;
            case 2:
                Instantiate(gamOverScreen);
                break;
        }
    }
}
