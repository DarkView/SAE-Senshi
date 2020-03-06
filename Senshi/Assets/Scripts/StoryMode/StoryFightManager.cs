using UnityEngine;

/// <summary>
/// alternate fightmanager used for storymode
/// by Zayarmoe
/// </summary>
public class StoryFightManager : Fightmanager
{
    /// <summary>
    /// object containing the continue screen prefab ; serialized private 
    /// </summary>
    [SerializeField] private Object continueScreen;
    /// <summary>
    /// object containing the game over screen prefab ; serialized private
    /// </summary>
    [SerializeField] private Object gamOverScreen;

    /// <summary>
    /// method to delete this script if story mode is not active ; protected override 
    /// </summary>
    protected override void CheckStoryMode()
    {
        if (!StoryManager.isStoryMode)
            Destroy(this);
    }

    /// <summary>
    /// method to check if a player has reached the needed amount of wins and prints the win or game over screen ; protected override
    /// </summary>
    protected override void CheckFightFinish()
    {
        if ((Player1Wins == NeededWins || Player2Wins == NeededWins) && !fightFinished)
        {
            fightFinished = true;
            StopAllCoroutines();
            Time.timeScale = 0;
        }
        else return;

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
