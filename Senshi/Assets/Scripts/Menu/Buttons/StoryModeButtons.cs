using UnityEngine;

/// <summary>
/// Buttons for story mode screens, game over and continue screen
/// by Zayarmoe
/// </summary>
public class StoryModeButtons : MonoBehaviour
{
    /// <summary>
    /// method to continue the story ; for button ; public 
    /// </summary>
    public void Continue()
    {
        CutSceneManager.StoryIndex++;
        StoryManager.LoadStage();
    }

    /// <summary>
    /// method to retry the current part of the story ; for button ; public 
    /// </summary>
    public void Retry()
    {
        StoryManager.LoadStage();
    }
}
