using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerInteraction playerInteraction;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerInteraction = GetComponent<PlayerInteraction>();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.LogWarning("TRYING TO MOVE");
        playerController.moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        playerController.lookInput = context.ReadValue<Vector2>();
    }

    /*public void OnJump(InputAction.CallbackContext context)
    {
        playerController.isJumping = context.ReadValueAsButton();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        playerController.isSprinting = context.ReadValueAsButton();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        playerController.ToggleCrouch(context.ReadValueAsButton());
    }*/

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }

    void OnEnable()
    {
/*        var playerInput = new InputSystem();
        playerInput.Player.Enable();

        // Movement
        playerInput.Player.Movement.performed += OnMove;
        playerInput.Player.Movement.canceled += OnMove;

        // Looking
        playerInput.Player.OnLook.performed += OnLook;
        playerInput.Player.OnLook.canceled += OnLook;

        // Jumping
        playerInput.Player.Jump.performed += ctx => playerController.isJumping = ctx.ReadValueAsButton();

        // Sprinting
        playerInput.Player.Sprint.performed += ctx => playerController.isSprinting = ctx.ReadValueAsButton();
        playerInput.Player.Sprint.canceled += ctx => playerController.isSprinting = ctx.ReadValueAsButton();

        // Courching
        playerInput.Player.Crouch.performed += ctx => playerController.ToggleCrouch(ctx.ReadValueAsButton());

        // Interaction
        playerInput.Player.Interact.performed += OnInteract;*/
    }

    private void OnDisable()
    {
        
    }


}
