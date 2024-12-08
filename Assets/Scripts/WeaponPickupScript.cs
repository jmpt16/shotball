using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour
{
	int randInt;
	private void Start()
	{
		randInt = (int)(Random.value * 3);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<WeaponSorterScript>().SetWeapon(randInt);
			Debug.Log(randInt);
			Destroy(gameObject);
		}
	}
}
