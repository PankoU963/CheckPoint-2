using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;

    private PlayerControls controls;
    private PlayerControls.GroundMovementActions groundMovement;

    [SerializeField] private Vector2 horizontalInput;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        movement = GetComponent<PlayerMovement>();

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += x => movement.OnJumpPressed();
    }
    
    private void Update() {
        movement.ReceiveInput(horizontalInput);
    }
    
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
