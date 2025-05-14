using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image healthBarFill; // Drag the HealthBarFill image here
    public float barUpdateSpeed = 0.25f; // How fast the bar updates

    private float targetFill; // The value we want to reach

    void Start()
    {
        currentHealth = maxHealth;
        targetFill = 1f;
        UpdateHealthBarInstant(); // Set it instantly at the start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        StartCoroutine(SmoothHealthBar());
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        StartCoroutine(SmoothHealthBar());
    }

    private IEnumerator SmoothHealthBar()
    {
        targetFill = (float)currentHealth / maxHealth;

        float startFill = healthBarFill.fillAmount;
        float elapsed = 0f;

        while (elapsed < barUpdateSpeed)
        {
            elapsed += Time.deltaTime;
            healthBarFill.fillAmount = Mathf.Lerp(startFill, targetFill, elapsed / barUpdateSpeed);
            yield return null;
        }

        healthBarFill.fillAmount = targetFill;
    }

    private void UpdateHealthBarInstant()
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) TakeDamage(10);
        if (Input.GetKeyDown(KeyCode.J)) Heal(10);
    }

}
