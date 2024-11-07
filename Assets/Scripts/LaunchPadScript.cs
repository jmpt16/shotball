using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadScript : MonoBehaviour
{
    public float boostForce;
    //se tocar, mudar velocidade para onde o cubo aponta*forca
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().velocity=(transform.forward.normalized * boostForce);
        }
    }
}
