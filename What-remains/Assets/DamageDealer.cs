using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weapondamage;

    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 9;

            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                Debug.Log($"Raycast hit: {hit.transform.name}"); // Log the name of the hit object
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    Debug.Log("Dealing damage");
                    enemy.TakeDemmage(weapondamage); // Ensure the method name matches in the Enemy script
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealtDamage.Clear();
        Debug.Log("Started dealing damage");
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
        Debug.Log("Stopped dealing damage");
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
