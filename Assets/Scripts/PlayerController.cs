using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8f;
    public float jumpForce = 7;
    public  float gravity = -25;
    public Transform grounCheck;
    public LayerMask groundLayer;
    public bool ableToMakeDoubleJump = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        controller.Move(direction*Time.deltaTime);
        direction.y += gravity * Time.deltaTime;
        bool isGrounded = Physics.CheckSphere(grounCheck.position,0.15f,groundLayer);


        if (isGrounded)
        {
            ableToMakeDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
            else

            {
                if (ableToMakeDoubleJump & Input.GetButtonDown("Jump"))
                {
                    Debug.Log("DoubleJump");

                    direction.y = jumpForce;
                    ableToMakeDoubleJump = false;
                }
                   

                
            }
        }
        controller.Move(direction * Time.deltaTime);
    }
}
