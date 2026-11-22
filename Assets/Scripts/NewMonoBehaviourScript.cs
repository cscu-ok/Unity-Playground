using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f; //movement speed
    public float acceleration = 15f; //acceleration speed
    public float deceleration = 20f; //deceleration speed

    //tracks our actual velocity, seperate from raw input
    private Vector3 currentVelocity = Vector3.zero;

    //raw input - getaxisraw returns exactly -1, 0, or 1 for the input axis, no smoothing
    private Vector2 inputMovement;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //freeze rotation so we only move


    }

    // Update is called once per frame
    void Update()
    { //read input every frame
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    { //physics updates happen here

        //build the direction we want to move
        //calculate target velocity based on input and move speed
        Vector3 targetDirection = (Vector3.right * inputMovement.x + Vector3.forward * inputMovement.y).normalized;

        Vector3 targetVelocity = targetDirection * moveSpeed;

        float rate = (targetDirection == Vector3.zero) ? deceleration : acceleration;

        //smoothly transition to target velocity using acceleration and deceleration
        currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, rate * Time.fixedDeltaTime);

        //apply the calculated velocity to the rigidbody
        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }

}
