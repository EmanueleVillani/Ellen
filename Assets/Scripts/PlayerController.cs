using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8f;
    private Vector3 starPos;


    public float jumpForce = 7;
    public  float gravity = -25;
    public Transform grounCheck;
    public LayerMask groundLayer;
    public bool ableToMakeDoubleJump = true;
    public Animator animator;
    public Transform model;
    

    void Start()
    {
        starPos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        //if(transform.position.x > starPos.x)
        //{
        //    transform.position = starPos;
        //}

       

        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        //controller.Move(direction*Time.deltaTime);
        animator.SetFloat("speed", Mathf.Abs(hInput));


        bool isGrounded = Physics.CheckSphere(grounCheck.position, 0.15f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);

        direction.y += gravity * Time.deltaTime;
        if (isGrounded)
        {
            //direction.y = -1;
            //ableToMakeDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump_1");
                direction.y = jumpForce;

            }
            else
            {
                
                if (ableToMakeDoubleJump & Input.GetButtonDown("Jump"))
                {
                    animator.SetTrigger("DounbleJump");
                    Debug.Log("Jump_2");
                    direction.y = jumpForce;
                    ableToMakeDoubleJump = false;
                }
            }
            if(hInput != 0)
            {
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
                model.rotation = newRotation;
            }
             
        }
        controller.Move(direction * Time.deltaTime);
    }


}
