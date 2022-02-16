using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float MaxSpeed = 5f;
    [SerializeField] private Transform startRay;
    private RaycastHit hit;
    [SerializeField] private bool canJump = false;
    public float Hp = 100;
    private Rigidbody rb;
    private bool IsJump;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var goDown = startRay.TransformDirection(new Vector3(0, -0.05f, 0));
        Debug.DrawRay(startRay.position, goDown, Color.red);
        if (Physics.Raycast(startRay.transform.position, goDown, out hit, maxDistance:0.05f))
        {
            if (hit.collider.CompareTag("ground"))
            {
                Debug.Log("on the floor");
                canJump = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                rb.AddForce(0, 250, 0);
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(0, 0, 50);
           
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb .AddForce(0, 0, -50);
        }
    }
    
    public IEnumerator StartWalk()
    {
        IsJump = true;
        yield return new WaitForSeconds(0.5f);
        IsJump = false;
    }

    public void FixedUpdate()
    {
        if(rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
}
