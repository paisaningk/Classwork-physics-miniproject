using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 3;
    public int Damage = 10;
    public bool StartLeft = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var goLeft = transform.TransformDirection(new Vector3(0, 0, 0.5f));
        var goRight = transform.TransformDirection(new Vector3(0, 0, -0.5f));
        var goUp = transform.TransformDirection(new Vector3(0, 0.7f, 0));

        // if (StartLeft)
        // {
        //     DrawRayAndRayCast(goLeft);
        // }
        // else
        // {
        //     DrawRayAndRayCast(goRight);
        // }

        rb.AddForce(0, 0, Speed);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.gameObject.GetComponent<Player>().Hp -= Damage;
        }

        if (other.CompareTag("ground"))
        {
            rb.velocity = Vector3.zero;
            Speed = -Speed;
        }
    }
}



