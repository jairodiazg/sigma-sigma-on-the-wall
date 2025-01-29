using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public SpriteAtlas atlas;

    public string[] idleSpriteNames;
    public string[] walkSpriteNames;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private int currentSpriteIndex;
    private float animationTimer;

    public float animationSpeed = 0.1f;
    public float moveSpeed = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Set initial sprite
        spriteRenderer.sprite = atlas.GetSprite(idleSpriteNames[0]);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        if (moveHorizontal != 0)
        {
            AnimateWalk(movement);
        }
        else
        {
            AnimateIdle();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocity.y);
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

        // Flip sprite based on movement direction
        spriteRenderer.flipX = movement.x < 0;
    }
}
