using UnityEngine;

/// <summary>
/// call pausemenu by button escape
/// by Zayarmoe Kyaw
/// </summary>
public class PauseMenuCaller : MonoBehaviour
{
    [SerializeField] private Object pauseMenuObject;
    public static bool paused;

    private void Update()
    {
        CallPauseMenu();
    }

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
