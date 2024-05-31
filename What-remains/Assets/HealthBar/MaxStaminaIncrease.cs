using UnityEngine;

public class StaminaCollectible : MonoBehaviour
{
    private const int collectiblesToIncreaseStamina = 3;
    private const int staminaIncreaseAmount = 20;
    private static int collectiblesCollected = 0;
    public float rotationSpeed = 50f; // Adjust the speed as needed

    void Update()
    {
        // Rotate the collectible slowly
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        StaminaManager staminaManager = other.GetComponent<StaminaManager>();
        if (staminaManager != null)
        {
            collectiblesCollected++;
            if (collectiblesCollected >= collectiblesToIncreaseStamina)
            {
                staminaManager.IncreaseMaxStamina(staminaIncreaseAmount);
                collectiblesCollected = 0; // Reset the count after increasing max stamina
            }

            Destroy(gameObject); // Remove the collectible after it has been collected
        }
    }
}
