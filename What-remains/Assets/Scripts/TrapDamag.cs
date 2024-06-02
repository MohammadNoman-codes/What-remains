using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamag : MonoBehaviour
{
    public float damageAmount = 10f;
    private HealthManager playerHealthManager;

    private void Start()
    {
        // Find the HealthManager component on the player game object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealthManager = player.GetComponent<HealthManager>();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Check if the colliding object is the "Player" game object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player using the HealthManager
            if (playerHealthManager != null)
            {
                playerHealthManager.TakeDamage((int)damageAmount);
            }
        }
    }
}