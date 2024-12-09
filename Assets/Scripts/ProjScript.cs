using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour
{
    public float speed = 5f;
    public string tag;
    public Collider[] hitColliders;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        hitColliders = Physics.OverlapSphere(transform.position, .5f);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.tag!= tag) 
            {
                if (hitCollider.GetComponent<PlayerControlScript>() || hitCollider.GetComponent<EnemyBehaviorScript>())
                    Destroy(hitCollider.gameObject);
                Collider[] blastColliders = Physics.OverlapSphere(transform.position, 5f);
                foreach (var item in blastColliders)
                {
                    if (item.GetComponent<Rigidbody>())
                        item.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 50);
                }
                Destroy(gameObject);
            }
            
        }
    }
}
