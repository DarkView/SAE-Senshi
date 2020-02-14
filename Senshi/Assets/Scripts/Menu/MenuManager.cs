using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Object mainMenu;
    [SerializeField] private Object settingsMenu;
    public static int menuState = 0;
    public int menu

    private void Update()
    {
        createMenu();
    }

    void createMenu()
    {
        switch (menuState)
        {
            case 0:
                Instantiate(mainMenu);
                break;
            case 1:
                Instantiate(settingsMenu);
                break;
            case 2:
                Instantiate(mainMenu);
                break;
        }
    }
}
