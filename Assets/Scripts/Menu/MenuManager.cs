using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void goToMenu(MenuList menu)
    {
        switch(menu)
        {
            case MenuList.Start:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuList.Help:
                SceneManager.LoadScene("HelpMenu"); 
                break;
            case MenuList.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            default:
                SceneManager.LoadScene("Gameplay");
                break;
        }
    }
}
