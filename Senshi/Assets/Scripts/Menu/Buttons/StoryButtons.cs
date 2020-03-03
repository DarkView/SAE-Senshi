using UnityEngine;

public class StoryButtons : MonoBehaviour
{
    [SerializeField] private int storyIndex;

    public void StartStory()
    {
        CutSceneManager.StoryIndex = storyIndex;
        StoryManager.LoadStage();
    }

}