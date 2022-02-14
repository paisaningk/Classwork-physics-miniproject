using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float fckHorizontal = 5f;
    private RaycastHit hit;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 vel = rb.velocity;
        if (vel.magnitude > fckHorizontal)
        {
            rb.velocity = vel.normalized * fckHorizontal;
        }
        
        var goDown = transform.TransformDirection(new Vector3(0, -0.5f, 0));
        Debug.DrawRay(transform.position, goDown, Color.red);
        if (Physics.Raycast(transform.position, goDown, out hit, maxDistance:0.5f))
        {
            if (hit.collider.tag == "ground")
            {
                Debug.Log("on the floor");
                canJump = true;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (canJump)
            {
                GetComponent<Rigidbody>().AddForce(0, 250, 0);
                canJump = false;
            }
        }
        
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, fckHorizontal);
        }

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -fckHorizontal);
        }
    }

}
