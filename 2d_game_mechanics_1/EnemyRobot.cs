using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyAnimation : MonoBehaviour
{
    public SpriteAtlas atlas; // Enemy's Sprite Atlas

    // Animation sprite names
    public string[] idleSprites;
    public string[] damagedSprites;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private float animationTimer = 0f;
    public float animationSpeed = 0.1f;

    private bool isDamaged = false;
    private bool isIdle = true; // Track if the enemy is idle or not

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
        // If the enemy is not damaged, continue with idle animation
        if (!isDamaged)
        {
            AnimateIdle();
        }
    }

    private void AnimateIdle()
    {
        // Only play idle animation if the enemy is not damaged
        if (isIdle)
        {
            animationTimer += Time.deltaTime;

            if (animationTimer >= animationSpeed)
            {
                animationTimer = 0f;
                currentSpriteIndex = (currentSpriteIndex + 1) % idleSprites.Length;
                spriteRenderer.sprite = atlas.GetSprite(idleSprites[currentSpriteIndex]);
            }
        }
    }

    public void TriggerDamagedAnimation()
    {
        // Ensure the damaged animation plays even if the enemy is idle or moving
        if (!isDamaged)
        {
            StartCoroutine(PlayDamagedAnimation());
        }
    }

    private IEnumerator PlayDamagedAnimation()
    {
        isDamaged = true; // Mark damaged animation as active
        isIdle = false; // Prevent idle animation during damage

        // Play the damaged animation
        for (int i = 0; i < damagedSprites.Length; i++)
        {
            spriteRenderer.sprite = atlas.GetSprite(damagedSprites[i]);
            yield return new WaitForSeconds(animationSpeed);
        }

        // Reset flags after the damaged animation finishes
        isDamaged = false;
        isIdle = true; // Allow idle animation to resume
    }
}
