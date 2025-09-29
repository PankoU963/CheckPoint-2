using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float sensivityX = 1f;
    [SerializeField] float sensivityY = 1f;
    float mouseX, mouseY;

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensivityX;
        mouseY = mouseInput.y * sensivityY;
    }
}
