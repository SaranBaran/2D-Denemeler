using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;


    void Start()
    {
        timeManager.timeScale = 1f;
    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //determines if the speed will be negative or positive for direction

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //part that gets the characters horizontal movement for animation

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true); //activating the jump animation
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding() //de-activating jump animation
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouch(bool isCrouch)
    {
        animator.SetBool("IsCrouch", isCrouch);
    }

    void SlowMo()
    {
        if (Input.GetButtonDown("RightShift"))
        {
            Time.timeScale = .2f;
        }
        if (Input.GetMouseButtonUp("RightShift"))
        {
            Time.timeScale = 1;

        }
    }


    void FixedUpdate()
    {
        //move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false; //we need to add this or the character wil jump forever
    }
}
