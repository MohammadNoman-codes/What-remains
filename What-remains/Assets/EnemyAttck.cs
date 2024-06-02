using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttck : MonoBehaviour
{
    //public EnemyDamageDealer Enemy;
    public GameObject enemyWeapon;
    private HealthManager healthManager;



    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        if (healthManager == null)
        {
            Debug.LogError("HealthManager not assigned in the Inspector!");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        bool yes = enemyWeapon.GetComponentInChildren<EnemyDamageDealer>().canDealDamge;
        if (yes)
        {
            healthManager.TakeDamage(15);
            Debug.Log(collision.gameObject.name + " has collided with us");
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {

    }
}
