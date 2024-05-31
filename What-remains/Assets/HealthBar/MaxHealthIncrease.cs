using UnityEngine;

public class MaxHealthIncrease : MonoBehaviour
{
    private const int collectiblesToIncreaseHealth = 3;
    private const int healthIncreaseAmount = 20;
    private static int collectiblesCollected = 0;
    public float rotationSpeed = 50f; // Adjust the speed as needed

    void Update()
    {
        // Rotate the collectible slowly
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        HealthManager playerHealth = other.GetComponent<HealthManager>();
        if (playerHealth != null)
        {
            collectiblesCollected++;
            if (collectiblesCollected >= collectiblesToIncreaseHealth)
            {
                playerHealth.IncreaseMaxHealth(healthIncreaseAmount);
                collectiblesCollected = 0; // Reset the count after increasing max health
            }

            Destroy(gameObject); // Remove the collectible after it has been collected
        }
    }
}
