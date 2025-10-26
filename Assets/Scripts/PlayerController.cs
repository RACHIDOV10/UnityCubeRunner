using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;   // Forward speed
    public float laneDistance = 3f;    // Distance between lanes
    private int currentLane = 1;       // 0 = Left, 1 = Middle, 2 = Right

    public float jumpForce = 7f;
    private bool isGrounded = true;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Constant forward movement (physics friendly)
        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        // Smooth lane movement (X)
        float targetX = (currentLane - 1) * laneDistance;
        Vector3 targetPos = new Vector3(targetX, rb.position.y, rb.position.z);
        Vector3 newPos = Vector3.Lerp(rb.position, targetPos, Time.fixedDeltaTime * 10f);
        rb.MovePosition(new Vector3(newPos.x, rb.position.y, rb.position.z));
    }

    void Update()
    {
        // Lane input
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            currentLane++;
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            currentLane--;

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Fall detection
        if (transform.position.y < -2f)
        {
            Debug.Log("You Fell! Game Over!");
            forwardSpeed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(" You hit an obstacle! Game Over!");
            forwardSpeed = 0;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
