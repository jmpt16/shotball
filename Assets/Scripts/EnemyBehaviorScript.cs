using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    public GameObject pivot, gunPivot;
    public Rigidbody rb;
    public float speed;
    float moveFwrd;
    float moveSide;
    float brake;
    public KeyCode InterKey;
    public float jumpSpeed;
    public float brakeForce = 5f;
    Vector3 movement;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindFirstObjectByType<PlayerControlScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        gunPivot.transform.LookAt(player.position);
        //para garantir que o movimento não é dependente do angulo vertical (cima/baixo)
        pivot.transform.rotation = new Quaternion(0, gunPivot.transform.rotation.y, 0, gunPivot.transform.rotation.w);
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
        Vector3 horizontalSpeed = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }
}
