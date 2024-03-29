using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float jumpForce = 5f;

    public CharacterController characterController;
    private bool isSprinting = false;
    //end ChatGPT

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] private bool isGrounded;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = IsGrounded();

        float moveSpeed = isSprinting ? sprintSpeed : walkSpeed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += Physics.gravity.y * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce;
        }

        // Continuous upward movement when spacebar is held
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    velocity.y = jumpForce;
        //}
        // Gradual decrease in upward velocity when spacebar is released
        else if (!Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, Physics.gravity.y, Time.deltaTime);
        }

        characterController.Move(velocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position - new Vector3(0, 1f, 0), Vector3.down, 0.6f, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - new Vector3(0, 1f, 0), transform.position - new Vector3(0, 1f, 0) + Vector3.down * 0.6f);
    }
}
