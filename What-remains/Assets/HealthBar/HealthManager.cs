using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // Damage player when we press the G key (for testing)
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage) // Change this to public
    {
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);
    }

    // Method to heal the player when collecting a health pickup
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetCurrentHealth(currentHealth);
    }

    // Called when the player collects a health pickup
    public void CollectHealthPickup(int healAmount)
    {
        Heal(healAmount);
    }

    // Method to increase max health
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth; // Optional: fully heal the player when max health is increased
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetCurrentHealth(currentHealth);
    }
}