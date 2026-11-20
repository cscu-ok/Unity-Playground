using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;    // Movement speed
    public float acceleration = 15f;    // How fast we ramp UP to full speed
    public float deceleration = 20f;    // How fast we ramp DOWN when no input (higher = snappier stop)

    // Tracks our actual current velocity, separate from raw input
    private Vector3 currentVelocity = Vector3.zero;

    // Raw input — GetAxisRaw returns exactly -1, 0, or 1 with no Unity smoothing
    private Vector2 inputMovement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;    // We don't want physics to rotate us, we only want to move
    }
    void Update()
    {   // Read input in Update — it polls every frame so nothing gets missed
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Build the direction we WANT to move
        // normalized ensures diagonal movement isn't faster than straight movement
        Vector3 targetDirection = (Vector3.right * inputMovement.x + Vector3.forward * inputMovement.y).normalized;

        // Calculate the velocity we're trying to reach
        Vector3 targetVelocity = targetDirection * moveSpeed;

        // Choose acceleration or deceleration rate depending on whether we have input
        float rate = (targetDirection == Vector3.zero) ? deceleration : acceleration;

        // Smoothly move currentVelocity toward the target velocity
        currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, rate * Time.fixedDeltaTime);

        // Move the Rigidbody to the new position using our smoothed velocity
        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }
}