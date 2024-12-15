using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : CharacterDataScript
{
    public GameObject camPivot;
    public float camPivotHeight;
    float moveFwrd;
    float moveSide;
    public KeyCode InterKey;

	public virtual void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        weapon = gunPivot.GetComponentInChildren<ShootScript>();
		CinemachineFreeLook cinemachine=FindAnyObjectByType<CinemachineFreeLook>();
        cinemachine.LookAt = camPivot.transform;
        cinemachine.Follow = camPivot.transform;
	}

    void Update()
    {
        //para garantir que o movimento não é dependente do angulo vertical (cima/baixo)
        pivot.transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);
        gunPivot.transform.rotation = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
		camPivot.transform.position = transform.position + Vector3.up* camPivotHeight;
		//input
		moveFwrd = Input.GetAxis("Horizontal");
        moveSide = Input.GetAxis("Vertical");
        brake = Input.GetAxis("Brake");

        if (Input.GetButton("Fire1"))
        {
			weapon.Fire();
		}
	}

    void FixedUpdate()
    {
        // movimento
        movement = Camera.main.transform.right * moveFwrd + Camera.main.transform.forward * moveSide;
        //movement.y = rb.velocity.y;
        movement = movement.normalized;

        if (brake > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.9f, rb.velocity.y, rb.velocity.z * 0.9f);
        }
        rb.AddForce(movement * speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetAxis("Jump") > 0)
        {
            rb.velocity += Vector3.up * jumpSpeed;
        }
    }
}
