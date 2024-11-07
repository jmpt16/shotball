using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    //quando colidir, inverte gravidade
    void OnCollisionEnter(Collision collision)
    {
        Physics.gravity = new Vector3(0, -Physics.gravity.y, 0);
    }
}
