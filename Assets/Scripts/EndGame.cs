using UnityEngine;

public class EndGame : MonoBehaviour
{
    [Header("UI")]
    public GameObject endGameText;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endGameText.SetActive(true);
        }
    }

    // [Header("Bounce")]
    // public float bounceForce = 20f;   // Tune this in the Inspector
    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.collider.CompareTag("Player"))
    //     {
    //         Debug.Log("Player fell off the edge");

    //         Movement movement = collision.collider.GetComponent<Movement>();
    //         if (movement != null)
    //         {
    //             movement.BounceUp(bounceForce);
    //         }
    //     }
    // }
}
