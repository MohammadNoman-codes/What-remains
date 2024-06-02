using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    public bool canDealDamge;
    bool hasDealDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;

    void Start()
    {
        canDealDamge = false;
        hasDealDamage = false;
    }

    void Update()
    {
        /*if (canDealDamge && !hasDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 8;
            Debug.Log("Inside the If condition");
            Debug.DrawRay(transform.position, -transform.up * weaponLength, Color.red); // Visualize the ray

            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                Debug.Log("Enemy hit: " + hit.transform.name); // Log the name of the hit object
                if (hit.transform.TryGetComponent(out PlayerController player))
                {
                    Debug.Log("Enemy dealt damage to player");
                    // player.TakeDamage(weaponDamage); // Implement this method in the PlayerController script
                    hasDealDamage = true;
                }
                else
                {
                    Debug.Log("Raycast hit something else: " + hit.transform.name);
                }
            }
        }*/

        RaycastHit hit;
        int layerMask = 1 << 8;

        if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
        {
            /*Debug.Log("Enemy hit: " + hit.transform.name); // Log the name of the hit object
            if (hit.transform.TryGetComponent(out PlayerController player))
            {
                Debug.Log("Enemy dealt damage to player");
                // player.TakeDamage(weaponDamage); // Implement this method in the PlayerController script
                hasDealDamage = true;
            }
            else
            {
                Debug.Log("Raycast hit something else: " + hit.transform.name);
            }*/

            Debug.Log("Enemy dealt damage to player");
        }

    }

    public void StartDealDamage()
    {
        canDealDamge = true;
        hasDealDamage = false; // Reset this so damage can be dealt
        //Debug.Log("Started dealing damage");
    }

    public void EndDealDamage()
    {
        canDealDamge = false;
        //Debug.Log("Stopped dealing damage");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
