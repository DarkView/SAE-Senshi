using UnityEngine;

public class StoryButtons : MonoBehaviour
{
    [SerializeField] private int storyIndex;

    public void StartStory()
    {
        StoryManager.StoryIndex = this.storyIndex;
        StoryManager.LoadStage();
    }

}