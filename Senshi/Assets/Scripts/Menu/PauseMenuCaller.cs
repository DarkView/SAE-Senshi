using System;
using UnityEngine;
using Object = UnityEngine.Object;

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
