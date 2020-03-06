using UnityEngine;

/// <summary>
/// call pausemenu by button escape
/// by Zayarmoe 
/// </summary>
public class PauseMenuCaller : MonoBehaviour
{
    /// <summary>
    /// bool value indicating whether the game is paused or not ; public static 
    /// </summary>
    public static bool paused;
    /// <summary>
    /// object containing the pause menu prefab ; serialized private 
    /// </summary>
    [SerializeField] private Object pauseMenuObject;

    /// <summary>
    /// update function called every frame ; calls CallPauseMenu() ; private 
    /// </summary>
    private void Update()
    {
        CallPauseMenu();
    }

    /// <summary>
    /// method to open the pause menu and pause the game by pressing the escape key 
    /// </summary>
    private void CallPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Instantiate(pauseMenuObject);
            Time.timeScale = 0;
            paused = true;
        }
    }
}
