// Using directives tell Unity which libraries we want to use.
// UnityEngine.U2D is specifically for 2D game development tools.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

// This class manages the character's animations, movement, and attacks.
public class SpriteAtlasExample : MonoBehaviour
{
    public SpriteAtlas atlas;
    public string[] idleSpriteNames;
    public string[] walkSpriteNames;
    public string[] attackSpriteNames1; // First attack animation sprites
    public string[] attackSpriteNames2; // Second attack animation sprites

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private int currentSpriteIndex;
    private float animationTimer;
    public float animationSpeed = 0.1f;
    public float moveSpeed = 1f;

    private bool isAttacking = false;
    private int attackCombo = 0;

    public GameObject attackHitbox; // Reference to the attack hitbox

    void Awake()
    {
        // Get references to components before Start() runs
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Ensure the attack hitbox starts disabled
        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    void Start()
    {
        // Set initial sprite after components are initialized
        spriteRenderer.sprite = atlas.GetSprite(idleSpriteNames[0]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
            StartCoroutine(AnimateAttack());
        }
        else if (!isAttacking)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (moveHorizontal != 0)
            {
                AnimateWalk(new Vector2(moveHorizontal, 0));
            }
            else
            {
                AnimateIdle();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocity.y);
        }
    }

    private void AnimateIdle()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer > animationSpeed)
        {
            animationTimer = 0f;
            currentSpriteIndex = (currentSpriteIndex + 1) % idleSpriteNames.Length;
            spriteRenderer.sprite = atlas.GetSprite(idleSpriteNames[currentSpriteIndex]);
        }
    }

    private void AnimateWalk(Vector2 movement)
    {
        animationTimer += Time.deltaTime;
        if (animationTimer > animationSpeed)
        {
            animationTimer = 0f;
            currentSpriteIndex = (currentSpriteIndex + 1) % walkSpriteNames.Length;
            spriteRenderer.sprite = atlas.GetSprite(walkSpriteNames[currentSpriteIndex]);
        }
        spriteRenderer.flipX = movement.x < 0;
    }

    private IEnumerator AnimateAttack()
    {
        isAttacking = true;
        attackHitbox.SetActive(true); // Activate hitbox when attack starts

        string[] currentAttackSprites = attackCombo % 2 == 0 ? attackSpriteNames1 : attackSpriteNames2;
        attackCombo++;

        for (int i = 0; i < currentAttackSprites.Length; i++)
        {
            spriteRenderer.sprite = atlas.GetSprite(currentAttackSprites[i]);
            yield return new WaitForSeconds(animationSpeed);
        }

        attackHitbox.SetActive(false); // Deactivate hitbox when attack ends
        isAttacking = false;
    }
}
