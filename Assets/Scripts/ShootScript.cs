using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float damage, range, rate, coolTime;
    public float spread;
    public int shotsFired;
    public Camera cam;
    public Transform prefab;
    public Transform[] shootPoints;
    public LayerMask layerMask;
    public PlayerControl playerControl;
    // Start is called before the first frame update
    public virtual void Shoot(Transform t)
    {
        for (int i = 0; i < shotsFired; i++)
        {
            Vector3 angle = Quaternion.Euler(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread)) * cam.transform.forward;
            //Debug.Log(Mathf.Sin(spread));
            if (Physics.Raycast(t.position, angle, out RaycastHit hit, range, layerMask))
            {
                Debug.Log(hit.transform.name);
                Instantiate(prefab, hit.point, t.rotation);
            }
        }
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= coolTime)
        {
            coolTime = Time.time + rate / 1000;
            foreach (Transform t in shootPoints)
			{
				Shoot(t);
			}
        }
    }
}
