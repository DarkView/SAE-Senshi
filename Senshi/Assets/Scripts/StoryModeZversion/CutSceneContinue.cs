using UnityEngine;

public class CutSceneContinue : MonoBehaviour
{
    private bool cutSceneStart = false;
    [SerializeField] private GameObject continueText;

    private void Start()
    {
        cutSceneStart = true;
    }

    private void Update()
    {
        CutSceneEndCheck();
        ContinueStoryOnButton();
    }

    private void CutSceneEndCheck()
    {
        if (!CutSceneManager.cutsceneActive && cutSceneStart)
        {
            Instantiate(continueText);
            cutSceneStart = false;
        }
    }

    private void ContinueStoryOnButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CutSceneManager.StoryIndex++;
            StoryManager.LoadStage();
        }
    }
}