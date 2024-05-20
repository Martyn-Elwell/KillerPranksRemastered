using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController characterController;

    [Header("Stats")]
    [SerializeField] private float lookSpeed = 5f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float crouchSpeed = 2.5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float crouchHeight = 1f;
    [SerializeField] private float standingHeight = 2f;

    
    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public Vector2 lookInput = Vector2.zero;
    [HideInInspector] public bool isJumping;
    [HideInInspector] public bool isSprinting;
    [HideInInspector] public bool isCrouching;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float verticalLookRotation;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        GroundCheck();

        Move();

        Jump();

        Look();
    }

    public void ToggleCrouch(bool isCrouchButtonPressed)
    {
        if (isCrouchButtonPressed)
        {
            isCrouching = !isCrouching;
            characterController.height = isCrouching ? crouchHeight : standingHeight;
        }
    }

    private void Move()
    {
        Debug.Log(moveInput);
        // Calculate movement
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        float speed = isCrouching ? crouchSpeed : (isSprinting ? sprintSpeed : walkSpeed);
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void Jump()
    {
        // Jump
        if (isJumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            isJumping = false;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void GroundCheck()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void Look()
    {
        // Horizontal rotation
        transform.Rotate(Vector3.up * lookInput.x * lookSpeed);

        // Vertical rotation
        verticalLookRotation -= lookInput.y * lookSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }
}
