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
    Rigidbody rb;
	public GameObject particlePrefab;

	private void Start()
	{
		rb=GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.transform!=shooter)
        {
			if (other.GetComponent<CharacterDataScript>())
			{
				other.GetComponent<CharacterDataScript>().health -= damage;
				other.GetComponent<Rigidbody>().AddExplosionForce(-1000, transform.position, 50);//dumbass workaround to weird bug
				other.transform.GetComponent<CharacterDataScript>().checkForDeath(rb.GetComponent<CharacterDataScript>());
			}
			Collider[] blastColliders = Physics.OverlapSphere(transform.position, range);
			Destroy(rb);
			foreach (var item in blastColliders)
			{
				if (item.GetComponent<Rigidbody>())
					item.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 50);
				if (item.GetComponent<CharacterDataScript>())
				{
					item.GetComponent<CharacterDataScript>().health -= Convert.ToInt32((range - Vector3.Distance(item.transform.position, transform.position)) / range * damage);
					Debug.Log(Convert.ToInt32((range - Vector3.Distance(item.transform.position, transform.position)) / range * damage)
						+ " | " + Convert.ToInt32((range - Vector3.Distance(item.transform.position, transform.position)) * damage));
					item.transform.GetComponent<CharacterDataScript>().checkForDeath(rb.GetComponent<CharacterDataScript>());
				}
			}
			Instantiate(particlePrefab, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	/*void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        hitColliders = Physics.OverlapSphere(transform.position, .5f);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.transform!= shooter) 
            {
                
            }
            
        }
    }*/
}
