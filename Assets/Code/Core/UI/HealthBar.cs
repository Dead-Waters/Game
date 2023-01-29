using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health playerHealth;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
