using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyAnimation : MonoBehaviour
{
    public SpriteAtlas atlas; // Enemy's Sprite Atlas

    // Animation sprite names
    public string[] idleSprites;
    public string[] attackSprites;
    public string[] damagedSprites;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private float animationTimer = 0f;
    public float animationSpeed = 0.1f;

    private bool isAttacking = false;
    private bool isDamaged = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get SpriteRenderer component
        if (idleSprites.Length > 0)
        {
            spriteRenderer.sprite = atlas.GetSprite(idleSprites[0]); // Set initial idle sprite
        }
    }

    void Update()
    {
        // If no special animation is playing, continue idle animation
        if (!isAttacking && !isDamaged)
        {
            AnimateIdle();
        }
    }

    private void AnimateIdle()
    {
        animationTimer += Time.deltaTime;

        if (animationTimer >= animationSpeed)
        {
            animationTimer = 0f;
            currentSpriteIndex = (currentSpriteIndex + 1) % idleSprites.Length;
            spriteRenderer.sprite = atlas.GetSprite(idleSprites[currentSpriteIndex]);
        }
    }

    private IEnumerator PlayAttackAnimation()
    {
        isAttacking = true; // Mark attack animation as active

        for (int i = 0; i < attackSprites.Length; i++)
        {
            spriteRenderer.sprite = atlas.GetSprite(attackSprites[i]);
            yield return new WaitForSeconds(animationSpeed);
        }

        isAttacking = false; // Return to idle after attack animation
    }

    private IEnumerator PlayDamagedAnimation()
    {
        isDamaged = true; // Mark damaged animation as active

        for (int i = 0; i < damagedSprites.Length; i++)
        {
            spriteRenderer.sprite = atlas.GetSprite(damagedSprites[i]);
            yield return new WaitForSeconds(animationSpeed);
        }

        isDamaged = false; // Return to idle after damaged animation
    }

    // Public method to trigger damaged animation from outside
    public void TriggerDamagedAnimation()
    {
        if (!isDamaged)
        {
            StartCoroutine(PlayDamagedAnimation());
        }
    }

    // Detect collision with the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Ensure the player has the tag "Player"
        {
            StartCoroutine(PlayDamagedAnimation());
        }
    }
}
