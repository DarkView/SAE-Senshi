using UnityEngine;

public class WinButtons : MonoBehaviour
{
    public void Continue()
    {
        StoryManager.StoryIndex++;
        StoryManager.LoadStage();
    }
}
