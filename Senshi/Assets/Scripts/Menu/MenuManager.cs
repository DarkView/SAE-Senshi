using UnityEngine;

/// <summary>
/// loads menu elements in MainMenu
/// by Zayarmoe Kyaw
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static int menuState = 0;
    public static bool menuExist;

    [SerializeField] private Object mainMenu;
    [SerializeField] private Object settingsMenu;

    private void Start()
    {
        StoryManager.isStoryMode = false;
        menuState = 0;
        menuExist = false;
    }

    private void Update()
    {
        createMenu();
    }

    void createMenu()
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
