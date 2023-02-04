using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
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

        // Disable player movement and actions
        // ...

        // Show game over screen or restart the game
        // ...
    }
}
