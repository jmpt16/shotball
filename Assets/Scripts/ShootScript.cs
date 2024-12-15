using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float range, rate, spread;
    protected float coolTime;
    public int damage,shotsFired, ammo,ammoCost;
    public Transform prefab;
    public Transform shootPoint;
    public LayerMask layerMask;
    // Start is called before the first frame update
    public virtual void Shoot(Transform t)
    {
        for (int i = 0; i < shotsFired; i++)
        {
            Vector3 angle = Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)) * t.transform.forward;
            //Debug.Log(Mathf.Sin(spread));
            if (Physics.Raycast(t.position, angle, out RaycastHit hit, range, layerMask))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.GetComponent<CharacterDataScript>()) 
                {
                    hit.transform.GetComponent<CharacterDataScript>().health -= damage;
                    hit.transform.GetComponent<CharacterDataScript>().checkForDeath(transform.parent.parent.GetComponent<CharacterDataScript>());
				}
                Instantiate(prefab, hit.point, t.rotation);
            }
        }
    }
    // Update is called once per frame
    public virtual void Fire()
    {
        if (ammo>0 && Time.time >= coolTime)
        {
            coolTime = Time.time + rate / 1000;
			Shoot(shootPoint);
			ammo -= ammoCost;
		}
    }
}
