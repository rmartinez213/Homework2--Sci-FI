//Game Programming HW1 
//================================================================
// Name        : FPSInput.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Attached to Player. Allows movement via WASD keys
//================================================================

using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private bool grounded = false;
    private CharacterController _charController;
    private float verticalVelocity;
    private float jumpForce = 5.0f;
    Rigidbody rb;



    void Start()
    {
        _charController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);

        if (_charController.isGrounded)
        {
            verticalVelocity = gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }

        }
        else
        {
            //verticalVelocity += gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftControl))
            {
                verticalVelocity = 7;
            }
            verticalVelocity += gravity * Time.deltaTime;
        }
        //
        //Vector3 moveV = Vector3.zero;
        //moveV.y = Input.GetAxis("Horizontal") * 5.0f;
        //moveV.y = verticalVelocity;
        //moveV.x = Input.GetAxis("Vertical") * 5.0f;
        //_charController.Move(moveV * Time.deltaTime);
        //

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, verticalVelocity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        //movement.y = verticalVelocity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);




        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            speed = 10;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = 3;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            speed = 6;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 3f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed = 3f;
        }
    }
}