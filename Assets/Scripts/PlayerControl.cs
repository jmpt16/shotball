using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerControl : MonoBehaviour
{
    public GameObject pivot,gunPivot;
    public Rigidbody rb;
    public float speed;
    float moveFwrd;
    float moveSide;
    float brake;
    public KeyCode InterKey;
    public float jumpSpeed;
    public float brakeForce = 5f;
    Vector3 movement;
    bool colliding;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //para garantir que o movimento não é dependente do angulo vertical (cima/baixo)
        pivot.transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);
        gunPivot.transform.rotation = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        //se gravidade virar, inverter antena e worldUp
        //input
        moveFwrd = Input.GetAxis("Horizontal");
        moveSide = Input.GetAxis("Vertical");
        brake = Input.GetAxis("Brake");
        
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
        Vector3 horizontalSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetAxis("Jump") > 0)
        {
            rb.velocity += Vector3.up * jumpSpeed;
        }
    }
}
