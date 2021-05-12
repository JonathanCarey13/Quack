using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController characterController;
    public Animator cameraAnimation;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -10f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBob();

        cameraAnimation.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * playerSpeed) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        characterController.Move(movementVector * Time.deltaTime);
    }

    void CheckForHeadBob()
    {
        if (characterController.velocity.magnitude > .1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

}
