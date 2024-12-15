using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjScript : MonoBehaviour
{
    public float speed = 5f,range=5f;
    public string tag;
    public Collider[] hitColliders;
    public Transform shooter;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        hitColliders = Physics.OverlapSphere(transform.position, .5f);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.transform!= shooter) 
            {
                
                Collider[] blastColliders = Physics.OverlapSphere(transform.position, range);
                foreach (var item in blastColliders)
                {
                    if (item.GetComponent<Rigidbody>())
                        item.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 50);
					if (item.GetComponent<CharacterDataScript>())
					{
						item.GetComponent<CharacterDataScript>().health -= Convert.ToInt32((range - Vector3.Distance(item.transform.position, transform.position)) / range * damage);
                        Debug.Log(Convert.ToInt32((range - Vector3.Distance(item.transform.position, transform.position)) /range*damage)
							+ " | "+Convert.ToInt32((range - Vector3.Distance(item.transform.position, transform.position)) * damage));
					}
				}
                Destroy(gameObject);
            }
            
        }
    }
}
