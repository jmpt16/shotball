using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }
    public event Action<int> onButtonTriggerEnter;
    public void ButtonTriggerEnter(int id)
    {
        if (onButtonTriggerEnter != null)
        {
            onButtonTriggerEnter(id);
        }
    }
    public event Action<int> onButtonTriggerExit;
    public void ButtonTriggerExit(int id)
    {
        if (onButtonTriggerExit != null)
        {
            onButtonTriggerExit(id);
        }
    }
}
