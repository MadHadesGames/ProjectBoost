using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] float thrustingForce = 1000.0f;
    [SerializeField] float rotationForce = 50;
    Rigidbody PlayerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationForce);
        }
    }

    private void ApplyRotation(float rotationSense)
    {
        PlayerRigidbody.freezeRotation = true; // Freezing physic's rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationSense * Time.deltaTime);
        PlayerRigidbody.freezeRotation = false; // Un-freezing physic's rotation
    }

    private void ProcessThrust()
    {
        
        if(Input.GetKey(KeyCode.Space))
        {
            PlayerRigidbody.AddRelativeForce(Vector3.up * thrustingForce * Time.deltaTime);
            Debug.Log("Thrusting...");
        }
    }
}
