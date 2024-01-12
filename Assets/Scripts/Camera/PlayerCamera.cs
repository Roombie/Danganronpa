using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float sensitivityX = 10f;
    [SerializeField] private float sensitivityY = 10f;

    [Header("Limits")]
    private const float minXRotation = -90f;
    private const float maxXRotation = 90f;

    [SerializeField] private Transform player; // Reference to the player object
    [SerializeField] private Transform orientation;

    private float xRotation;  // Represents vertical rotation
    private float yRotation;  // Represents horizontal rotation

    private Vector2 inputRotation;

    private void Update()
    {
        // Handle input for camera rotation
        HandleInputRotation();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Read the pointer delta or right stick input
        inputRotation = context.ReadValue<Vector2>();
    }

    private void HandleInputRotation()
    {
        // Calculate the rotation based on input and adjust the camera and player orientation
        float inputX = inputRotation.x * sensitivityX * Time.deltaTime;
        float inputY = inputRotation.y * sensitivityY * Time.deltaTime;

        yRotation += inputX;
        xRotation -= inputY;

        // Clamp the vertical rotation within specified limits
        xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);

        // Rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        // Rotate player object along the x-axis
        player.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
