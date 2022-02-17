using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float JumpSpeed = 5f;
    [SerializeField] private float MaxSpeed = 5f;
    [SerializeField] private bool canJump = false;
    public float Hp = 100;
    private Rigidbody rb;
    private RaycastHit hit;

    // Start is called before the first frame update
    private void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (canJump)
            {
                canJump = false;
                rb.AddForce(0, 250, 0,ForceMode.Force);
                Debug.Log("Jump");
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            if (canJump)
            {
                rb.AddForce(0, 0, 100,ForceMode.Force);
            }
            else
            {
                rb.AddForce(0, 0, 50,ForceMode.Force);
            }
           
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (canJump)
            {
                rb.AddForce(0, 0, -100,ForceMode.Force);
            }
            else
            {
                rb.AddForce(0, 0, -50,ForceMode.Force);
            }
        }

        if (canJump)
        {
            rb.mass = 1;
            if(rb.velocity.magnitude > MaxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
            }
        }
        else
        {
            rb.mass = 2;
            if(rb.velocity.magnitude > MaxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, JumpSpeed);
            }
        }
        Debug.Log(rb.velocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            canJump = true;
        }
    }
}
