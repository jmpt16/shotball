using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataScript : MonoBehaviour
{
    public int health;
	public int points=0;
	public GameObject pivot, gunPivot;
	public Rigidbody rb;
	public float speed;
	public float jumpSpeed;
	public float brakeForce = 5f;
	protected float brake;
	protected Vector3 movement;
	public ShootScript weapon;
	public bool dead = false;

	public void checkForDeath(CharacterDataScript originShot) 
	{
		if (health<=0 && !dead)
		{
			StartCoroutine(Respawn());
			dead = true;
			if (originShot != this)
			{
				originShot.points++;
			}
		}
	}

	IEnumerator Respawn()
	{
		GetComponent<Renderer>().enabled=false;
		GetComponent<Collider>().enabled=false;
		pivot.GetComponent<Renderer>().enabled = false;
		if (weapon)
		{
			Destroy(weapon.gameObject);
		}
		health = 100;
		yield return new WaitForSeconds(5);
		gameObject.transform.position = Vector3.up;
		GetComponent<Renderer>().enabled = true;
		GetComponent<Collider>().enabled = true;
		pivot.GetComponent<Renderer>().enabled = true;
		weapon = null;
		dead = false;
	}
}
