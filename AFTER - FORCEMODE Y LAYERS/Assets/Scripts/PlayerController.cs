using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;
    [SerializeField] private float horsePower = 10.0f;
    [SerializeField] private float turnSpeed = 20.0f;

    [SerializeField] WheelCollider[] allWheels;

    private Rigidbody playerRb;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (IsOnGround()) { 
            MoveCar();
        }
    }

    private void MoveCar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddRelativeForce(Vector3.back * horsePower * forwardInput, ForceMode.Acceleration);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }



    private bool IsOnGround()
    {
        if (!allWheels[0].isGrounded) return false;
        if (!allWheels[1].isGrounded) return false;
        if (!allWheels[2].isGrounded) return false;
        if (!allWheels[3].isGrounded) return false;
        return true;
    }
}
