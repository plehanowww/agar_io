
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScipt : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
  

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        if (FindObjectOfType<PlayerSettings>())
        {
            FindObjectOfType<PlayerSettings>().gameStarted = true;
        }        
    }
    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

}
