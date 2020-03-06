using UnityEngine;

/// <summary>
/// button used in story selection screen
/// by Zayarmoe 
/// </summary>
public class StoryButtons : MonoBehaviour
{
    /// <summary>
    /// int value indicating which part of the story to load ; serialized private
    /// </summary>
    [SerializeField] private int storyIndex;

    /// <summary>
    /// method to load a story stage depending on this storyIndex ; for button ; public 
    /// </summary>
    public void StartStory()
    {
        CutSceneManager.StoryIndex = storyIndex;
        StoryManager.isStoryMode = true;
        StoryManager.LoadStage();
    }
}