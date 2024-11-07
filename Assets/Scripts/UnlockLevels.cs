
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevels : MonoBehaviour
{
    public int levelUnlock;
    int numberOfUnlocked;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            numberOfUnlocked = PlayerPrefs.GetInt("isUnlocked");

            if (numberOfUnlocked <= levelUnlock)
            {
                PlayerPrefs.SetInt("isUnlocked", numberOfUnlocked + 1);
            }
        }
    }
}

