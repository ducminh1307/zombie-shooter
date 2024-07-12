using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthBar;

    private Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = stats.currentHealth / (float)stats.maxHealth;
    }
}
