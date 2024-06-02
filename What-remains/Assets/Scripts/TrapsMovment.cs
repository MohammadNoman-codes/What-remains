using UnityEngine;

public class SawTrapController : MonoBehaviour
{
    public float rotationSpeed = 45f; // Speed at which the saw trap rotates (in degrees per second)
    public float minAngle = -45f; // Minimum angle of rotation
    public float maxAngle = 45f; // Maximum angle of rotation
    public float speedMultiplier = 1f; // Multiplier to adjust the rotation speed
    public float movementSpeed = 2f; // Speed at which the saw trap moves left and right (units per second)
    public GameObject Trail; // Reference to the GameObject that defines the trail
    public int damage = 20; // Amount of damage to apply to the player

    private bool isRotatingClockwise = true;
    private bool isMovingRight = true;
    private float trailMinX, trailMaxX;

    private void Start()
    {
        // Get the trail boundaries from the Trail GameObject
        if (Trail != null)
        {
            Renderer renderer = Trail.GetComponent<Renderer>();
            if (renderer != null)
            {
                Bounds bounds = renderer.bounds;
                trailMinX = bounds.min.x;
                trailMaxX = bounds.max.x;
            }
        }
    }

    private void Update()
    {
        RotateSawTrap();
        MoveSawTrap();
    }

    private void RotateSawTrap()
    {
        // Rotate the saw trap on the X axis
        if (isRotatingClockwise)
        {
            // Rotate the saw trap clockwise on the X axis
            transform.Rotate(Vector3.right * rotationSpeed * speedMultiplier * Time.deltaTime);

            // Check if the saw trap has reached the maximum angle
            if (transform.localEulerAngles.x >= maxAngle)
            {
                isRotatingClockwise = false;
            }
        }
        else
        {
            // Rotate the saw trap counter-clockwise on the X axis
            transform.Rotate(Vector3.right * -rotationSpeed * speedMultiplier * Time.deltaTime);

            // Check if the saw trap has reached the minimum angle
            if (transform.localEulerAngles.x <= minAngle)
            {
                isRotatingClockwise = true;
            }
        }
    }

    private void MoveSawTrap()
    {
        // Move the saw trap left and right within the trail
        if (isMovingRight)
        {
            // Move the saw trap to the right
            float newX = transform.position.x + movementSpeed * Time.deltaTime;

            // Check if the new position is within the trail boundaries
            if (newX <= trailMaxX - 1f)
            {
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            else
            {
                isMovingRight = false;
            }
        }
        else
        {
            // Move the saw trap to the left
            float newX = transform.position.x - movementSpeed * Time.deltaTime;

            // Check if the new position is within the trail boundaries
            if (newX >= trailMinX + 1f)
            {
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            else
            {
                isMovingRight = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has a HealthManager component
        HealthManager healthManager = other.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            // Apply damage to the player
            healthManager.TakeDamage(damage);
        }
    }
}
