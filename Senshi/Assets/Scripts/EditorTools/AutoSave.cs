#if UNITY_EDITOR 
using UnityEditor;
using UnityEditor.SceneManagement;
using Debug = UnityEngine.Debug;

// Based on https://www.reddit.com/r/Unity3D/comments/97bt65/autosave_on_run_editor_script/
// Added by Nils

/// <summary>
/// Class used to autosave the open scenes once we click the play button 
/// </summary>
[InitializeOnLoad]
public class AutoSave
{
    /// <summary>
    /// Called by InitializeOnLoad, adds the SaveOnPlay method to the list of methods to execute when we change play mode
    /// </summary>
    static AutoSave()
    {
        EditorApplication.playModeStateChanged += SaveOnPlay;
    }

    /// <summary>
    /// Called every time we change the play mode, only saves if the mode is exiting edit mode
    /// </summary>
    /// <param name="state"></param>
    private static void SaveOnPlay(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            Debug.Log("Entering Play Mode - Saving!");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }

}
#endif