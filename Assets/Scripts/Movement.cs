using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    public float acceleration = 15f;
    public float deceleration = 20f;

    private Vector3 currentVelocity = Vector3.zero;
    private Vector2 inputMovement;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 targetDirection = (Vector3.right * inputMovement.x + Vector3.forward * inputMovement.y).normalized;
        Vector3 targetVelocity = targetDirection * moveSpeed;
        float rate = (targetDirection == Vector3.zero) ? deceleration : acceleration;
        currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, rate * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }
    // public void BounceUp(float force)
    // {
    //     // Kill all horizontal momentum so the bounce is purely vertical
    //     currentVelocity = Vector3.zero;
    //     rb.linearVelocity = Vector3.zero;
    //     rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    // }
}