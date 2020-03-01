using UnityEngine.SceneManagement;
public static class StoryManager
{
    public static bool isStoryMode = false;
    public static int StoryIndex = 1;
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
        //11 --> Fight Scene 2 Akuma
        //12 --> End Scene

        switch (StoryIndex)
        {
            case 1:
            case 2:
            case 4:
            case 5:
            case 7:
            case 8:
            case 10:
            case 11:
                LoadCutScene(StoryIndex);
                break;
            case 3:
            case 6:
            case 9:
                InitStage(StoryIndex);
                break;
        }

    }

    public static void LoadCutScene(int index)
    {
        //ruft CutSceneManager Script auf
        CutSceneManager.InitCutScene(index);

        //if cutscene finished
        StoryIndex += 1;
        StoryManager.LoadStage();
    }

    public static void InitStage(int index)
    {
        //ruft fight Script auf, übergibt 2 Spieler (GameObjects)
        SceneManager.LoadScene(2);
    }

    public static void StoryContinue()
    {
        StoryIndex += 1;
        StoryManager.LoadStage();
    }

}
