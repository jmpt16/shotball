using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShootScript : ShootScript
{
	public override void Shoot(Transform t)
	{
		Transform projectile = Instantiate(prefab, t.position, t.rotation);
		projectile.GetComponent<ProjScript>().speed += playerControl.rb.velocity.magnitude;
		projectile.GetComponent<ProjScript>().tag += transform.tag;
	}
}
