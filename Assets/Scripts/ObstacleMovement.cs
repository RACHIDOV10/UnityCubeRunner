using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 10f;   // Movement speed toward player
    private float destroyDelay = 5f; // optional delay before destruction
    private bool startDestroyTimer = false;

    void Update()
    {
        // Move toward the player
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Optional: start a destroy timer if obstacle is behind player
        if (transform.position.z < -10f && !startDestroyTimer)
        {
            startDestroyTimer = true;
            Destroy(gameObject, destroyDelay); // destroy after 5 seconds
        }
    }
}
