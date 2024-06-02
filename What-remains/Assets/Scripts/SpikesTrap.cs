using UnityEngine;

public class SpikesTrap : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply to the player

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                Debug.Log("Player detected. Applying damage.");
                playerHealth.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("HealthManager not found on Player.");
            }
        }
    }
}