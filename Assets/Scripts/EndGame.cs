using UnityEngine;

public class EndGame : MonoBehaviour
{
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("Player fell off the edge");
    //     }
    // }

    [Header("Bounce")]
    public float bounceForce = 15f;   // Tune this in the Inspector
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell off the edge");

            Movement movement = other.GetComponent<Movement>();
            if (movement != null)
            {
                movement.BounceUp(bounceForce);
            }
        }
    }
}
