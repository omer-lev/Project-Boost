using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 200;
    [SerializeField] float boostSpeed = 150f;

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
        Rotate();
        Boost();
    }


    private void Boost()
    {
        // BOOST
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * boostSpeed * Time.deltaTime);
            if (!boostSound.isPlaying)
            {
                boostSound.Play();
            }
        }
        else
        {
            boostSound.Stop();
        }
    }


    private void Rotate()
    {
        // ROTATION
         rb.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        rb.freezeRotation = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly collision");
                break;

            case "Fuel":
                print("Fuel collision");
                break;

            default:
                print("Non-friendly collision");
                break;
        }
    }
}