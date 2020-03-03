using UnityEngine;

/// <summary>
/// Buttons for story mode screens, game over and continue screen
/// by Zayarmoe
/// </summary>
public class StoryModeButtons : MonoBehaviour
{
    public void Continue()
    {
        CutSceneManager.StoryIndex++;
        StoryManager.LoadStage();
    }

    public void Retry()
    {
        StoryManager.LoadStage();
    }
}
