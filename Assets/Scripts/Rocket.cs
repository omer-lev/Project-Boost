using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        // boost
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
        }

        // rotation
        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating right");
        }
    }
}
