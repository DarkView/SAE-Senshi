using UnityEngine.SceneManagement;

/// <summary>
/// Manages the Story Mode. Chooses FightScene or CutScene depending on Index.
/// By Louis
/// </summary>
public static class StoryManager
{
    /// <summary>
    /// bool to check if we are in Story Mode
    /// </summary>
    public static bool isStoryMode = false;

    /// <summary>
    /// New static Object CutSceneManager so we can use it
    /// </summary>
    public static CutSceneManager CutSceneManager = new CutSceneManager();

    /// <summary>
    /// Choose Story Stage with index StoryIndex
    /// </summary>
    public static void LoadStage()
    {
        //1 --> Opening Scene
        //2 --> Prefight Scene Riu
        //3 --> Fight Scene Riu
        //4 --> Postfight Scene Riu
        //5 --> Prefight Scene Akai
        //6 --> Fight Scene Akai
        //7 --> Postfight Scene Akai
        //8 --> Prefight Scene Akuma
        //9 --> Fight Scene 1 Akuma
        //10 --> Midfight Scene Akuma
        //12--> Fight Scene 2 Akuma
        //11 --> End Scene

        switch (CutSceneManager.StoryIndex)
        {
            //Fight Cases
            case 3:
            case 6:
            case 9:
            case 12:
                InitStage();
                break;
        }
        
        if (CutSceneManager.StoryIndex % 3 != 0)
        {
            LoadCutScene(CutSceneManager.StoryIndex);
        }

    }

    /// <summary>
    /// loads CutScene from CutSceneManager depending on StoryIndex
    /// </summary>
    /// <param name="index"></param>
    public static void LoadCutScene(int index)
    {
        CutSceneManager.InitCutScene(index);
    }

    /// <summary>
    /// loads Fight Scene
    /// </summary>
    public static void InitStage()
    {
        SceneManager.LoadScene(2);
    }
}
