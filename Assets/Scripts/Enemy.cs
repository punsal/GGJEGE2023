using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float chaseRange = 7f;
    public float attackRange = 1f;
    public float moveSpeed = 5f;
    public float stopDistance = 1.5f;

    private Transform player;
    private Rigidbody enemyRigidbody;

    [SerializeField] private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyRigidbody = GetComponent<Rigidbody>();
        StopChase();
    }

    void Update()
    {
        var distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
            TryToAttack();
        }
        else
        {
            StopChase();
        }
    }

    private void ChasePlayer()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.position);   
    }

    void TryToAttack()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            GetComponent<EnemyAttack>().Attack();
        }
    }

    private void StopChase()
    {
        navMeshAgent.isStopped = true;
    }
}
