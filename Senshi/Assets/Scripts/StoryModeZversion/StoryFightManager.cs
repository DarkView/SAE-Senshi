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
        neededWins = 1;
    }

    protected override void CheckFightFinish()
    {
        if (_player1Wins != neededWins || _player2Wins != neededWins)
            return;

        _winner = (_player1Wins == neededWins) ? 1 : 2;

        switch (_winner)
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
