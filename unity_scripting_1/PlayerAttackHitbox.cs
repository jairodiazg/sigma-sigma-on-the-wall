using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Assuming the enemy has the "Enemy" tag.
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyAnimation component from the enemy
            EnemyRobotAnimation enemyAnim = other.GetComponent<EnemyRobotAnimation>();
                // Trigger the damaged animation
                enemyAnim.TriggerDamagedAnimation();
        }
    }
}