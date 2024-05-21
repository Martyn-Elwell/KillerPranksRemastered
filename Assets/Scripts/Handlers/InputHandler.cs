using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerControls playerControls;

    void Start()
    {
        LockCursor(true);
    }

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        playerControls.Player.Enable();

        playerControls.Player.Move.performed += OnMove;
        playerControls.Player.Move.canceled += OnMove;
        playerControls.Player.Look.performed += OnLook;
        playerControls.Player.Look.canceled += OnLook;
        playerControls.Player.Jump.performed += ctx => playerController.isJumping = ctx.ReadValueAsButton();
        playerControls.Player.Sprint.performed += ctx => playerController.isSprinting = ctx.ReadValueAsButton();
        playerControls.Player.Sprint.canceled += ctx => playerController.isSprinting = ctx.ReadValueAsButton();
        playerControls.Player.Crouch.performed += ctx => ToggleCrouch(ctx.ReadValueAsButton());
    }

    void OnDisable()
    {
        playerControls.Player.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        playerController.moveInput = context.ReadValue<Vector2>();
    }
    void OnLook(InputAction.CallbackContext context)
    {
        playerController.lookInput = context.ReadValue<Vector2>();
    }

    void ToggleCrouch(bool isCrouchButtonPressed)
    {
        if (isCrouchButtonPressed)
        {
            playerController.Crouch();
        }
    }

    private void LockCursor(bool lockState)
    {
        if (lockState)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
