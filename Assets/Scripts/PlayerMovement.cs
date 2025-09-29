using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed = 12f;
    Vector2 horizontalInput;

    [SerializeField] float gravity = -20f;
    Vector3 verticalVelocity = Vector3.zero;

    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;

    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] bool jump;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
   
        isGrounded = Physics.CheckSphere(transform.position, 1.2f, groundMask);
        if (isGrounded)
            verticalVelocity.y = 0f; //Resets the vertical velocity

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        characterController.Move(horizontalVelocity * Time.deltaTime);

        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 input)
    {
        horizontalInput = input;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }
}
