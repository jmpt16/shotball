using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerControl : MonoBehaviour
{
    public GameObject pivot, worldUp,antenaPivot;
    public Rigidbody rb;
    public float speed;
    public float maxSpeed;
    float moveFwrd;
    float moveSide;
    float brake;
    public KeyCode InterKey;
    public float jumpSpeed;
    public float brakeForce = 5f;
    public CinemachineFreeLook camSetup;
    Vector3 movement;
    public AudioSource Trampolim;
    public AudioSource Lançamento;
    public AudioSource Gravidade;
    public AudioSource Morte;
    public AudioSource Botao;
    public AudioSource Final;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //para garantir que o movimento não é dependente do angulo vertical (cima/baixo)
        pivot.transform.rotation = new Quaternion(0, Camera.main.transform.rotation.y, 0, Camera.main.transform.rotation.w);
        //se gravidade virar, inverter antena e worldUp
        if (Physics.gravity.y > 0)
        {
            antenaPivot.transform.rotation = new Quaternion(0, 0, 180, antenaPivot.transform.rotation.w);
            worldUp.transform.rotation = new Quaternion(180, 0, 0, worldUp.transform.rotation.w);
        }
        else
        {
            antenaPivot.transform.rotation = new Quaternion(0, 0, 0, antenaPivot.transform.rotation.w);
            worldUp.transform.rotation = new Quaternion(0, 0, 0, worldUp.transform.rotation.w);
        }
        //input
        moveFwrd = Input.GetAxis("Horizontal");
        moveSide = Input.GetAxis("Vertical");
        brake = Input.GetAxis("Brake");

    }

    void FixedUpdate()
    {
        // movimento
        movement = Camera.main.transform.right * moveFwrd + Camera.main.transform.forward * moveSide;
        movement.y = rb.velocity.y;
        movement = movement.normalized;

        if (brake > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * 0.9f, rb.velocity.y, rb.velocity.z * 0.9f);
        }
        rb.AddForce(movement * speed);
        Vector3 horizontalSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trampolim")
        {
            Trampolim.Play();
        }

        if (collision.gameObject.tag == "Gravidade")
        {
            Gravidade.Play();
        }

        if (collision.gameObject.tag == "Morte")
        {
            Morte.Play();
        }

        if (collision.gameObject.tag == "Botao")
        {
            Botao.Play();
        }

        if (collision.gameObject.tag == "Final")
        {
            Final.Play();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Lançamento")
        {
            Lançamento.Play();
        }
    }
}
