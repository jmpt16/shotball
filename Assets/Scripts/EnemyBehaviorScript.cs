using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : CharacterDataScript
{
    Transform target;
	bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
		weapon = gunPivot.GetComponentInChildren<ShootScript>();
	}

    // Update is called once per frame
    void Update()
    {
		//para garantir que o movimento não é dependente do angulo vertical (cima/baixo)

		RaycastHit hit;
		pivot.transform.rotation = new Quaternion(0, gunPivot.transform.rotation.y, 0, gunPivot.transform.rotation.w);
        if(weapon && weapon.ammo>0)
        {
			if (!target)
			{
				target = FindFirstObjectByType<PlayerControlScript>().transform;
			}
			if (Physics.Linecast(transform.position, target.position, out hit) && hit.transform == target.transform)
			{
				weapon.Fire();
			}
			
		}
        else
        {
			if (!target)
			{
				Transform tMin = null;
				float minDist = Mathf.Infinity;
				Vector3 currentPos = transform.position;
				foreach (WeaponPickupScript pickupScript in FindObjectsByType<WeaponPickupScript>(FindObjectsSortMode.None))
				{
					float dist = Vector3.Distance(pickupScript.transform.position, currentPos);
					if (dist < minDist)
					{
						tMin = pickupScript.transform;
						minDist = dist;
					}
				}
				if (tMin)
				{
					target = tMin;
				}
				else
				{
					target = FindFirstObjectByType<PlayerControlScript>().transform;
				}

			}
		}

		gunPivot.transform.LookAt(target.position);

	}

    void FixedUpdate()
    {
        // movimento
        movement = pivot.transform.forward;

        if (brake > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.9f, rb.velocity.y, rb.velocity.z * 0.9f);
        }
        rb.AddForce(movement * speed);
    }

	private void OnCollisionStay(Collision collision)
	{
		if (rb.velocity.y > 0)
		{
			rb.velocity += Vector3.up * jumpSpeed;
		}
	}
}
