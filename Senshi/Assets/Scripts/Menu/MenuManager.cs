using UnityEngine;

/// <summary>
/// loads menu elements in MainMenu
/// by Zayarmoe 
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// int value indicating what menu was called from ; public static 
    /// </summary>
    public static int menuState = 0;
    /// <summary>
    /// bool value indicating whether a menu eist or not ; public static 
    /// </summary>
    public static bool menuExist;

     /// <summary>
     /// object containing the main menu prefab ; serialized private 
     /// </summary>
    [SerializeField] private Object mainMenu;
     /// <summary>
     /// object containing the settings menu prefab ; serialized private 
     /// </summary>
    [SerializeField] private Object settingsMenu;

     /// <summary>
     /// start function called on instance ; sets default values ; private 
     /// </summary>
    private void Start()
    {
        StoryManager.isStoryMode = false;
        menuState = 0;
        menuExist = false;
    }

     /// <summary>
     /// update function called every frame ; calls createMenu() ; private
     /// </summary>
    private void Update()
    {
        createMenu();
    }

     /// <summary>
     /// method to create menu when none exist ; private
     /// </summary>
    private void createMenu()
    {
        if (!menuExist)
        {
            switch (menuState)
            {
                case 0:
                    Instantiate(mainMenu);
                    menuExist = true;
                    break;
                case 1:
                    Instantiate(settingsMenu);
                    menuExist = true;
                    break;
                case 2:
                    Instantiate(mainMenu);
                    menuExist = true;
                    break;
            }
        }
    }
}
