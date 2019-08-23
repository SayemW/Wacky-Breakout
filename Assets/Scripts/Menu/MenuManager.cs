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
            case MenuList.Game:
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuList.GameOver:
                Object.Instantiate(Resources.Load("GameOver"));
                break;
            default:
                break;
        }
    }
}
