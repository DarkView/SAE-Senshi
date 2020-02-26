using UnityEngine;

/// <summary>
/// loads menu elements in MainMenu
/// by Zayarmoe Kyaw
/// </summary>
public class MenuManager : MonoBehaviour
{
    [SerializeField] private Object mainMenu;
    [SerializeField] private Object settingsMenu;
    public static int menuState = 0;
    public static bool menuExist;

    private void Start()
    {
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
