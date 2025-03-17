using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerAnimation : MonoBehaviour
{
    public SpriteAtlas atlas; // Sprite Atlas for all animations

    // Idle animation sprites
    public string[] idleSpriteNames;
    // Attack animation sprites
    public string[] attackSprites1 = { "Attack1_1", "Attack1_2", "Attack1_3", "Attack1_4", "Attack1_5" };
    public string[] attackSprites2 = { "Attack2_1", "Attack2_2", "Attack2_3", "Attack2_4", "Attack2_5" };
    // Damaged animation sprites
    public string[] damagedSprites;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex;
    private float animationTimer;
    public float animationSpeed = 0.08f;

    private int attackIndex = 0; // Determines which attack animation to play
    private bool canAttack = true; // Prevents spam attacks
    public float attackCooldown = 0.05f; // Short cooldown time in seconds
    private bool isAttackInProgress = false; // Tracks if an attack is in progress
    private bool isDamaged = false; // Tracks if damaged animation is playing

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get SpriteRenderer component
        if (idleSpriteNames.Length > 0)
        {
            spriteRenderer.sprite = atlas.GetSprite(idleSpriteNames[0]); // Set initial idle sprite
        }
    }

    void Update()
    {
        // Play attack animation when Right Arrow is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow) && canAttack && !isAttackInProgress && !isDamaged)
        {
            StartCoroutine(TriggerAttack());
        }

        // Animate idle only when no attack or damaged animation is playing
        if (canAttack && !isAttackInProgress && !isDamaged)
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
            currentSpriteIndex = (currentSpriteIndex + 1) % idleSpriteNames.Length;
            spriteRenderer.sprite = atlas.GetSprite(idleSpriteNames[currentSpriteIndex]);
        }
    }

    // Trigger attack animation with a short cooldown
    private IEnumerator TriggerAttack()
    {
        isAttackInProgress = true; // Mark attack as in progress
        canAttack = false; // Prevent further attacks

        // Play the attack animation for the current attack set
        string[] currentAttackSprites = (attackIndex == 0) ? attackSprites1 : attackSprites2;

        // Animate the current attack
        for (int i = 0; i < currentAttackSprites.Length; i++)
        {
            spriteRenderer.sprite = atlas.GetSprite(currentAttackSprites[i]);
            yield return new WaitForSeconds(animationSpeed);

            // Introduce a cooldown just before the attack finishes
            if (i == currentAttackSprites.Length - 2)
            {
                yield return new WaitForSeconds(attackCooldown);
            }
        }

        // Alternate between attack animations after the attack animation is done
        attackIndex = 1 - attackIndex;

        // After the attack, wait for cooldown before allowing another attack
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        isAttackInProgress = false;
    }

    // Play the damaged animation
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

    // Detect collision with enemy and play damaged animation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Ensure the enemy has the tag "Enemy"
        {
            StartCoroutine(PlayDamagedAnimation());
        }
    }
}
