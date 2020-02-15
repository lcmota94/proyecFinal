using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent enemyAgent;
    private Transform playerTransform;

    public float maxHealth = 5;
    public float currentHealth;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        if (currentHealth > 0)
        {   
            enemyAgent.SetDestination(playerTransform.position);
            Debug.Log("Distance to player: " +
                enemyAgent.remainingDistance);
            if (enemyAgent.remainingDistance <= 1f &&
                enemyAgent.hasPath)
            {
                enemyAnimator.SetFloat("Speed", 0f);
                enemyAnimator.SetTrigger("Attack");
                enemyAnimator.SetBool("Punch", true);
            }
            else
                enemyAnimator.SetFloat("Speed", enemyAgent.speed);
        }
        else
        {
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //GetComponentInChildren<SkinnedMeshRenderer>().material = damageMaterial;
    }

    public void Die()
    {
        enemyAnimator.SetTrigger("Dead");
        enemyAgent.isStopped = true;
        //GetComponentInChildren<SkinnedMeshRenderer>().material = deadMaterial;
        //dissolve.Play();
        Collider collider = GetComponent<CapsuleCollider>();
        collider.enabled = false;
        Destroy(this.gameObject);
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().score += 1;
            //UIVrController.instance.AddPoint();
            Destroy(this.gameObject);
        }
    }
}
