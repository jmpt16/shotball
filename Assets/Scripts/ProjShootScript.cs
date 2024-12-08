using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShootScript : ShootScript
{
	public override void Shoot(Transform t)
	{
		Instantiate(prefab, t.position, t.rotation);
	}
}
