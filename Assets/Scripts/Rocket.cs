using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource boostSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        // BOOST
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
            if (!boostSound.isPlaying)
            {
                boostSound.Play();
            }
        }
        else
        {
            boostSound.Stop();
        }


        // ROTATION
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
