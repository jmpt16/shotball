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

	public void checkForDeath(CharacterDataScript otherGuy) 
	{
		if (health<=0)
		{
			Destroy(gameObject);
			otherGuy.points++;
		}
	}
}
