using UnityEngine;

public class SawTrap : MonoBehaviour
{
    public float rotationSpeed = 45f; // Speed at which the saw trap rotates (in degrees per second)
    public float minAngle = -45f; // Minimum angle of rotation
    public float maxAngle = 45f; // Maximum angle of rotation
    public float speedMultiplier = 1f; // Multiplier to adjust the rotation speed
    public int damageAmount = 10; // Amount of damage to apply to the player

    private bool isRotatingClockwise = true;

    private void Update()
    {
        RotateSawTrap();
    }

    private void RotateSawTrap()
    {
        // Rotate the saw trap on the Z axis
        if (isRotatingClockwise)
        {
            // Rotate the saw trap clockwise on the Z axis
            transform.Rotate(Vector3.forward * rotationSpeed * speedMultiplier * Time.deltaTime);

            // Check if the saw trap has reached the maximum angle
            if (transform.localEulerAngles.z >= maxAngle)
            {
                isRotatingClockwise = false;
            }
        }
        else
        {
            // Rotate the saw trap counter-clockwise on the Z axis
            transform.Rotate(Vector3.forward * -rotationSpeed * speedMultiplier * Time.deltaTime);

            // Check if the saw trap has reached the minimum angle
            if (transform.localEulerAngles.z <= minAngle)
            {
                isRotatingClockwise = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}