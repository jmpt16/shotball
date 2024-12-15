using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WeaponPickupScript : MonoBehaviour
{
	public GameObject[] weapons;
	int randInt;
	private void Start()
	{
		randInt = (int)(Random.value * weapons.Length);
		Instantiate(weapons[randInt], transform);
	}

	private void Update()
	{
		transform.Rotate(new Vector3(0,10*Time.deltaTime,0));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<CharacterDataScript>())
		{
			CharacterDataScript character = other.gameObject.GetComponent<CharacterDataScript>();
            if (character.weapon!=null)
			{
				Destroy(character.weapon.gameObject);
			}
			GameObject weapon = Instantiate(weapons[randInt], character.gunPivot.transform);
			character.weapon=weapon.GetComponent<ShootScript>();
			Destroy(gameObject);
		}
	}
}
