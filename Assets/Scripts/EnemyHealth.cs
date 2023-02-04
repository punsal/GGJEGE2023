using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Play the damage animation
        // ...

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play the death animation
        // ...

        // Disable enemy movement and actions
        // ...

        // Remove the enemy from the scene
        // ...
    }
}
