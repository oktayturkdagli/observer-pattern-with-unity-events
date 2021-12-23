using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour
{
    //^i beatuty
    [SerializeField] LayerMask groundLayers;
    [SerializeField] LayerMask wallLayers;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private Transform[] groundChecks;
    [SerializeField] private Transform[] wallChecks;

    private float gravity = -50;
    private CharacterController characterController;
    private Animator playerAnimator;
    private Vector3 movementVector;
    private bool isGrounded = true, isBlocked = false;
    private float horizontalInput, verticalInput;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //isGrounded
        isGrounded = GroundCheck();

        //isBlocked
        isBlocked = WallCheck();

        //For Gravity
        GravityForceApply();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (!isBlocked)
        {
            Movement();
        }



    }



    private bool GroundCheck()
    {
        foreach (Transform groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.01f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                return true;
            }
        }
        return false;
    }

    private bool WallCheck()
    {
        foreach (var wallCheck in wallChecks)
        {
            if (Physics.CheckSphere(wallCheck.position, 0.01f, wallLayers, QueryTriggerInteraction.Ignore))
            {
                return true;
            }
        }

        return false;
    }

    private void GravityForceApply()
    {
        if (isGrounded && movementVector.y < 0)
        {
            movementVector.y = 0;
        }
        else
        {
            movementVector.y += gravity * Time.deltaTime;
        }
    }

    private void Movement()
    {
        movementVector.x = horizontalInput * runSpeed;
        movementVector.z = verticalInput * runSpeed;
        characterController.Move(movementVector * Time.deltaTime);
        if (movementVector.x != 0 || movementVector.z != 0)
            playerAnimator.SetFloat("speed", 1);
        else
            playerAnimator.SetFloat("speed", 0);
    }

    private void Jump()
    {
        movementVector.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
    }



}
