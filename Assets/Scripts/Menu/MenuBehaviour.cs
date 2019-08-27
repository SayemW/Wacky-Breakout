using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public void OnQuitClick()
    {
        AudioManager.Play(AudioClipName.MenuClick);
        Application.Quit();
    }

    public void OnPlayClick()
    {
        AudioManager.Play(AudioClipName.MenuClick);
        MenuManager.goToMenu(MenuList.Game);
    }

    public void onBackClick()
    {
        AudioManager.Play(AudioClipName.MenuClick);
        MenuManager.goToMenu(MenuList.Start);
    }
    public void onHelpClick()
    {
        AudioManager.Play(AudioClipName.MenuClick);
        MenuManager.goToMenu(MenuList.Help);
    }

    public void onQuitGameClick()
    {
        AudioManager.Play(AudioClipName.MenuClick);
        Time.timeScale = 1;
        MenuManager.goToMenu(MenuList.Start);
    }

    public void onResumeClick()
    {
        AudioManager.Play(AudioClipName.MenuClick);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
