using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    public void Retry()
    {
        StoryManager.LoadStage();
    }
}
