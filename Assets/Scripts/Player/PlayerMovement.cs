using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private Transform orientation;

    private bool isSprinting = false;
    private Vector2 movementInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = orientation.forward * movementInput.y + orientation.right * movementInput.x;

        float speed = isSprinting ? sprintSpeed : moveSpeed;

        SetVelocity(moveDirection, speed);
    }

    private void SetVelocity(Vector3 moveDirection, float speed)
    {
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        // Toggle sprinting state on button press
        ToggleSprint(context.performed);
    }

    private void ToggleSprint(bool shouldSprint)
    {
        isSprinting = shouldSprint;
    }
}
