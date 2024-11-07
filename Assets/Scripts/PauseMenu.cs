using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause;

    public GameObject pause;
    public GameObject options;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        isPause = false;
    }

     void Pause()
    {
        pause.SetActive(true);
        isPause = true;
    }

    public void OpenOptions()
    {
        pause.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
        pause.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
