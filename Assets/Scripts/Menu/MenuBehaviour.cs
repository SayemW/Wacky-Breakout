using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnPlayClick()
    {
        MenuManager.goToMenu(MenuList.Game);
    }

    public void onBackClick()
    {
        MenuManager.goToMenu(MenuList.Start);
    }
    public void onHelpClick()
    {
        MenuManager.goToMenu(MenuList.Help);
    }

    public void onQuitGameClick()
    {
        Time.timeScale = 1;
        MenuManager.goToMenu(MenuList.Start);
    }

    public void onResumeClick()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
