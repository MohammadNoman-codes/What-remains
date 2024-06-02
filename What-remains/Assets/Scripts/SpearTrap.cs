using UnityEngine;
using System.Collections;

public class SpearTrap : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the spear moves
    public float minY = 2.5f; // Minimum Y position for the spear
    public float maxY = 5f; // Maximum Y position for the spear
    public float freezeTimeAtMax = 0.5f; // Time in seconds to freeze at max Y
    public float freezeTimeAtMin = 0.5f; // Time in seconds to freeze at min Y
    public int damageAmount = 10; // Amount of damage to apply to the player

    private Vector3 startPosition;
    private Coroutine spearMovementCoroutine;

    void Start()
    {
        startPosition = transform.position;
        StartSpearMovement();
    }

    void StartSpearMovement()
    {
        spearMovementCoroutine = StartCoroutine(MoveSpearCoroutine());
    }

    IEnumerator MoveSpearCoroutine()
    {
        while (true)
        {
            // Move the spear up and down within the specified Y range
            float newY = Mathf.Lerp(minY, maxY, Mathf.Sin(Time.time * moveSpeed));
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Check if the spear has reached the max or min Y
            if (newY <= minY)
            {
                yield return StartCoroutine(FreezeAtMinY());
            }
            else if (newY >= maxY)
            {
                yield return StartCoroutine(FreezeAtMaxY());
            }

            yield return null;
        }
    }

    IEnumerator FreezeAtMaxY()
    {
        // Freeze the spear at the max Y for the specified time
        transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        yield return new WaitForSeconds(freezeTimeAtMax);
        transform.position = startPosition;
    }

    IEnumerator FreezeAtMinY()
    {
        // Freeze the spear at the min Y for the specified time
        transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        yield return new WaitForSeconds(freezeTimeAtMin);
        transform.position = startPosition;
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