using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSorterScript : MonoBehaviour
{
    public GameObject[] weapons;
    // Start is called before the first frame update

	public void SetWeapon(int index)
	{
		for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i==index);
        }
	}
}
