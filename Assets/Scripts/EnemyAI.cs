using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Vector3 patrolPoint;
    public Animator enemyAnim;

    private bool isPlayerDetected = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(ChangePatrolPoint());
    }

    void Update()
    {
        FollowPlayer();
    }
    

    void FollowPlayer()
    {
        if (isPlayerDetected)
        {

            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(patrolPoint);
        }

        if (agent.velocity.magnitude > 0.1f)
        {
            enemyAnim.Play("Walking");
        }
        else
        {
            enemyAnim.Play("Idle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerDetected = false;
        }
    }

    IEnumerator ChangePatrolPoint()
    {
        while (true)
        {
            enemyAnim.Play("Walking");
            yield return new WaitForSeconds(5f);
            enemyAnim.Play("Idle");
            patrolPoint = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        }
    }

}
