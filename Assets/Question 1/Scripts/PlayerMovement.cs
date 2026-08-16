using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    float acceleration = 7f;
    Vector3 playerMovementInput = Vector3.zero;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        playerMovementInput = new Vector3(context.ReadValue<Vector2>().x, playerMovementInput.y, context.ReadValue<Vector2>().y);
    }

    void FixedUpdate()
    {
        rb.AddForce(playerMovementInput * acceleration, ForceMode.VelocityChange);
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, moveSpeed);
    }
}
