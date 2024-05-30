using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healAmount = 20;

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
