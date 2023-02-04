using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseRange = 7f;
    public float attackRange = 1f;
    public float moveSpeed = 5f;
    public float stopDistance = 1.5f;

    private Transform player;
    private Rigidbody enemyRigidbody;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {

        Vector3 moveDirection = player.position - transform.position;
        if (moveDirection.magnitude > stopDistance)
        {
            enemyRigidbody.MovePosition(transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            GetComponent<EnemyAttack>().Attack();
        }
    }

    public void TakeDamage(float damage) { }
}
