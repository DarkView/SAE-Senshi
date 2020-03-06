using UnityEngine;

/// <summary>
/// Continue button for cut scenes
/// by Zayarmoe 
/// </summary>
public class CutSceneContinue : MonoBehaviour
{
    /// <summary>
    /// bool value indicating whether the cut scene has started ; private 
    /// </summary>
    private bool cutSceneStart = false;
    /// <summary>
    /// gameObject containing the continue indicator prefab ; serialized private 
    /// </summary>
    [SerializeField] private GameObject continueText;

    /// <summary>
    /// start function called on instance ; set cut scene status as started ; private 
    /// </summary>
    private void Start()
    {
        cutSceneStart = true;
    }

    /// <summary>
    /// update function called every frame ; calls CutSceneEndCheck() ContinueStoryOnButton() ; private
    /// </summary>
    private void Update()
    {
        CutSceneEndCheck();
        ContinueStoryOnButton();
    }

    /// <summary>
    /// method to instance/display that next scene can be called ; private 
    /// </summary>
    private void CutSceneEndCheck()
    {
        if (!CutSceneManager.cutsceneActive && cutSceneStart)
        {
            Instantiate(continueText);
            cutSceneStart = false;
        }
    }

    /// <summary>
    /// method to allow user to continue to next scene on button press keycode e ; private 
    /// </summary>
    private void ContinueStoryOnButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CutSceneManager.StoryIndex++;
            StoryManager.LoadStage();
        }
    }
}