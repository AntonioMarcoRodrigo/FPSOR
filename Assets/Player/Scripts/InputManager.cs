using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Aim aim;
    
    private PlayerControls controls;
    private PlayerControls.MovementActions groundMovement;

    private Vector2 horizontalInput;
    private Vector2 mouseInput;
    
    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.Movement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        aim.ReceiveInput(mouseInput);
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}