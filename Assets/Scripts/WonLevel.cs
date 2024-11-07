using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonLevel : MonoBehaviour
{
    public GameObject win ;
    public GameObject levels;
    public GameObject options;

    public void OpenLevels()
    {
        win.SetActive(false);
        levels.SetActive(true);
    }

    public void OpenOptions()
    {
        win.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
        win.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
