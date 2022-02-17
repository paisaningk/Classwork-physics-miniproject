using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public int MaxSpeed = 5;
    public Vector3 Speed;
    public int Damage = 10;
    public bool StartLeft = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Speed = new Vector3(0, 0, 500) * Time.fixedDeltaTime / rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        // var goLeft = transform.TransformDirection(new Vector3(0, 0, 0.5f));
        // var goRight = transform.TransformDirection(new Vector3(0, 0, -0.5f));
        // var goUp = transform.TransformDirection(new Vector3(0, 0.7f, 0));

        rb.velocity += Speed;
        
        if(rb.velocity.magnitude > MaxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
    
    
    
    private void DrawRayAndRayCast(Vector3 direction)
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, direction, Color.red);
        if (Physics.Raycast(transform.position, direction, out hit, maxDistance:0.7f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                var a = hit.transform.gameObject;
                a.GetComponent<Player>().Hp -= Damage;
            }
            else
            {
                Debug.Log("hit");
                rb.velocity = Vector3.zero;
                Speed = -Speed;
                if (StartLeft)
                {
                    StartLeft = false;
                }
                else
                {
                    StartLeft = true;
                }
            }
          
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.gameObject.GetComponent<Player>().Hp -= Damage;
            rb.velocity = Vector3.zero;
            Speed = -Speed;
        }

        if (collision.collider.CompareTag("ground"))
        {
            rb.velocity = Vector3.zero;
            Speed = -Speed;
        }
    }
}



