using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Rigidbody2D player;
    public HealthBar healthBar;
    private Movement movement;

    public int curHealth = 0;
    public int minHealth = 0;
    public int maxHealth = 100;

    public int devHealPlayer = 10;
    public int devDamagePlayer = 10;
    public bool devGodMode;


    float startYPos, endYPos;
    public float damageThreshold = 3f;
    public float damageMultiplier = 2.85f;
    bool firstCall = true;
    bool damaged = false;

    void Start()
    {
        UpdateHealth(maxHealth);
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        // Dev cheat: Add health
        if (Input.GetKeyDown(KeyCode.UpArrow))
            UpdateHealth(curHealth + devHealPlayer);

        // Dev cheat: Remove health
        if (Input.GetKeyDown(KeyCode.DownArrow))
            UpdateHealth(curHealth - devDamagePlayer);

        // Fall Damage
        if (!movement.IsGrounded())
        {
            if (transform.position.y > startYPos)
                firstCall = true;
            if (firstCall)
            {
                firstCall = false;
                damaged = true;
                startYPos = transform.position.y;
            }
        }
        else
        {
            endYPos = transform.position.y;
            if (damaged && (startYPos - endYPos) > damageThreshold)
            {
                damaged = false;
                firstCall = true;

                float amount = startYPos - endYPos - damageThreshold;
                float damage = (damageMultiplier == 0f) ? amount : amount * damageMultiplier;
                UpdateHealth(curHealth - Mathf.RoundToInt(damage));
            }
        }

        // Death
        if (curHealth <= 0)
            Die();
    }

    public void UpdateHealth(int health)
    {
        if (devGodMode)
            return;

        if (health < minHealth)
            health = minHealth;
        else if (health > maxHealth)
            health = maxHealth;

        curHealth = health;
        healthBar.SetHealth(curHealth);
    }

    void Die()
    {
        
    }
}