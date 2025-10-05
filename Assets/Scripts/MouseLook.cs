using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensivityX = 1f;
    [SerializeField] float sensivityY = 1f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera; //To connect the camera
    [SerializeField] float xClamp = 85f; //To limit the camera rotation up and down
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles; //Saves the rotation of the object in eulerAngles.
        //Rememeber that unity stores rotations as Quaternions internally.
        targetRotation.x = xRotation; //saves the xRotation into the X component of targetRotation
        playerCamera.eulerAngles = targetRotation; //applies the targetRotation to the camera
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensivityX;
        mouseY = mouseInput.y * sensivityY;
    }
}
