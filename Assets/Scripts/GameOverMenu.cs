using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverMenu;

    public void BacktoMain()
    {

        gameOverMenu.SetActive(false);
        mainMenu.SetActive(true);

    }
}
