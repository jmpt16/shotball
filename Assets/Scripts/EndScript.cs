using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScript : MonoBehaviour
{
    public int sceneIndex;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("ChangeScene", 2.0f);
    }
    void ChangeScene() {
        SceneManager.LoadScene(sceneIndex);
    }
}