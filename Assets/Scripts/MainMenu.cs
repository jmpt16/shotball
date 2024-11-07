using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Level;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject levelsMenu;

    public void Play()
    {
        SceneManager.LoadScene(Level);
    }
    public void OpenLevels()
    {
        mainMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void CloseLevels()
    {
        levelsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
