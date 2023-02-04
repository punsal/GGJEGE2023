using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1f;
    public float attackDamage = 5f;
    public float attackRate = 1f;
    private float nextAttackTime = 2f;
    public LayerMask playerLayer;
    public Transform attackPoint;

    private Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }

    }

    public void Attack()
    {
        // Play the attack animation
        // ...

        // Detect player in range
        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, attackRange, playerLayer);

        // Deal damage to player
        foreach (Collider player in hitPlayers)
        {
            Debug.Log("attack");
            
            player.GetComponentInParent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
