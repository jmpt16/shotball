using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShootScript : ShootScript
{

	public Rigidbody rb;
	private void Awake()
	{
		rb = transform.parent.parent.GetComponent<Rigidbody>();
	}
	public override void Shoot(Transform t)
	{
		Transform projectile = Instantiate(prefab, t.position, t.rotation);
		projectile.GetComponent<ProjScript>().speed += rb.velocity.magnitude;
		projectile.GetComponent<ProjScript>().tag = transform.tag;
		projectile.GetComponent<ProjScript>().shooter = rb.transform;
		projectile.GetComponent<ProjScript>().damage = damage;
	}
}
