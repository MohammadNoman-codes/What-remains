using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healAmount = 20;
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
            playerHealth.CollectHealthPickup(healAmount);
            Destroy(gameObject); // Remove the collectible after it has been collected
        }
    }
}
