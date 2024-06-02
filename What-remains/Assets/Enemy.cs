using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 1;

    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;


    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    float timepassed;
    float newDestinationCD = 0.5f;

    public GameObject enemyWeapon;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (player != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
            if (timepassed >= attackCD)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    animator.SetTrigger("Attack");
                    timepassed = 0;
                }
            }
            timepassed += Time.deltaTime;

            if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
            {
                newDestinationCD = 0.5f;
                agent.SetDestination(player.transform.position);
            }
            newDestinationCD -= Time.deltaTime;
            transform.LookAt(player.transform);
        }
    }

    public void TakeDemmage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("Damage");
        Debug.Log("The halth is: ");
        Debug.Log(health);
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    public void StratDealDamage()
    {
        enemyWeapon.GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        enemyWeapon.GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, attackRange);
        Gizmos.color += Color.yellow;
        Gizmos.DrawSphere(transform.position, aggroRange);
    }*/
}
