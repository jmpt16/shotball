using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
