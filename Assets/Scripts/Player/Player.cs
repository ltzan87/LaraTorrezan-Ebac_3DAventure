using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;

    public float gravity = -9.8f;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float jumpSpeed = 15f;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    private float _vSpeed = 0f;


    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed *
            Time.deltaTime, 0);

        var InputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * Input.GetAxis("Vertical") * speed;

        if(characterController.isGrounded)
        {
            _vSpeed = 0;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _vSpeed = jumpSpeed;
            }
        }

        var isWalking = InputAxisVertical != 0;
        if(isWalking)
        {
            if(Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        _vSpeed -= gravity * Time.deltaTime;
        speedVector.y = _vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }
}