using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public float boostForce;
    //quando for para saltar, adicionar velocidade paralela a placa 
    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody && Input.GetAxis("Jump")>0)
        {
            collision.rigidbody.velocity+= transform.up.normalized * boostForce;
        }
    }
}
