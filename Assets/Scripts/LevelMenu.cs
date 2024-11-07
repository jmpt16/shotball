using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] levels;
    int unlockLevel;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("isUnlocked"))
        {
            PlayerPrefs.SetInt("isUnlocked", 1);

            unlockLevel = PlayerPrefs.GetInt("inUnlocked");

            for(int i=0; i<levels.Length;i++)
            {
                levels[i].interactable = false;
            }
        }
    }

    private void Update()
    {
        unlockLevel = PlayerPrefs.GetInt("inUnlocked");
        for (int i=0; i<unlockLevel; i++)
        {
            levels[i].interactable = true;
        }
    }
}
