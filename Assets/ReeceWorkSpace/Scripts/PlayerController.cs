using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float crouchSpeed = 2.5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float crouchHeight = 1f;
    public float standingHeight = 2f;

    private CharacterController characterController;
    private Vector2 moveInput;
    private bool isJumping;
    private bool isSprinting;
    private bool isCrouching;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        var playerInput = new InputSystem();
        playerInput.Player.Enable();

        playerInput.Player.Movement.performed += OnMove;
        playerInput.Player.Movement.canceled += OnMove;
        //playerInput.Player.Jump.performed += ctx => isJumping = ctx.ReadValueAsButton();
        playerInput.Player.Sprint.performed += ctx => isSprinting = ctx.ReadValueAsButton();
        playerInput.Player.Sprint.canceled += ctx => isSprinting = ctx.ReadValueAsButton();
        //playerInput.Player.Crouch.performed += ctx => ToggleCrouch(ctx.ReadValueAsButton());
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void ToggleCrouch(bool isCrouchButtonPressed)
    {
        if (isCrouchButtonPressed)
        {
            isCrouching = !isCrouching;
            characterController.height = isCrouching ? crouchHeight : standingHeight;
        }
    }

    void Update()
    {
        // Ground check

        //isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Calculate movement
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        float speed = isCrouching ? crouchSpeed : (isSprinting ? sprintSpeed : walkSpeed);
        characterController.Move(move * speed * Time.deltaTime);

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
}
