using System.Collections;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private  Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = FindAnyObjectByType<Animator>();

    }

    void Update()
    {
        // Damage player when we press the G key (for testing)
       /* if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(20);
        }*/
    }

<<<<<<< Updated upstream
    void TakeDamage(int damage)
=======
    public void TakeDamage(int damage)
>>>>>>> Stashed changes
    {
        animator.SetTrigger("damage");
        currentHealth -= damage;
        healthBar.SetCurrentHealth(currentHealth);
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }


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
<<<<<<< Updated upstream
=======

    private IEnumerator Die()
    {
        animator.SetTrigger("Die");
        
       yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
        Application.LoadLevel("Scene1");
    }
>>>>>>> Stashed changes
}
