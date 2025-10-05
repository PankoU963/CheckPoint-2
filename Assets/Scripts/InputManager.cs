using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;

    [SerializeField] MouseLook mouseLook; // Reference to the MouseLook script

    private PlayerControls controls;
    private PlayerControls.GroundMovementActions groundMovement;

    [SerializeField] private Vector2 horizontalInput;
    Vector2 mouseInput; //To store the input from the mouse

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        movement = GetComponent<PlayerMovement>();

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += x => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }
    
    private void Update() {
        movement.ReceiveInput(horizontalInput);
        movement.ReceiveInput(mouseInput); //pass "mouseInput" to "ReceiveInput" method on "mouseLook" script
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
