using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Assuming the enemy has the "Enemy" tag.
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyAnimation component from the enemy
            EnemyAnimation enemyAnim = other.GetComponent<EnemyAnimation>();
                // Trigger the damaged animation
                enemyAnim.TriggerDamagedAnimation();
        }
    }
}
