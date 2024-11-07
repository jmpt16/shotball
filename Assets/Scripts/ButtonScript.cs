using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject wall;
    public bool toActivate;

    private void OnCollisionEnter(Collision collision)
    {
        wall.SetActive(toActivate);
    }
}
