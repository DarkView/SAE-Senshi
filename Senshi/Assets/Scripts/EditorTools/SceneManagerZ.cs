using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerZ : MonoBehaviour
{
    [SerializeField] private Scene[] scenes;
    [SerializeField] private int sceneCount;

    private void Start()
    {
        sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        scenes = SaveAllScene();
        LoadAllScenes(scenes);
    }

    private Scene[] SaveAllScene()
    {
        Scene[] sceneArray = new Scene[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            sceneArray[i] = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(i);
        }
        return sceneArray;
    }

    private void LoadAllScenes(Scene[] scenesToLoad)
    {
        foreach (var scene in scenesToLoad)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
        }
    }
}
