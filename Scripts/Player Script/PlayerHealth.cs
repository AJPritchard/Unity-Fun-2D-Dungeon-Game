using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public bool isDead = false;

    public GameObject player;
    public Transform healthBar;
    private readonly float HealthBarMaxSize;

    /**
     * Player Health takes in the player object and sets its max health to 100
     */
    public PlayerHealth(GameObject player)
    {
        this.player = player;
        currentHealth = PlayerStats.MaxHealth;

        healthBar = GameObject.Find("Health Bar").transform;
        HealthBarMaxSize = healthBar.localScale.x;



        AdjustHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            //Debug.Log("DIED");
            isDead = true;
        }
        AdjustHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > PlayerStats.MaxHealth)
        {
            currentHealth = PlayerStats.MaxHealth;
        }
        AdjustHealthBar();
    }

    public void AdjustHealthBar()
    {

        Vector3 localScale = healthBar.localScale;
        float percOfHealth = currentHealth / PlayerStats.MaxHealth;
        localScale.x = HealthBarMaxSize * percOfHealth;
        healthBar.localScale = localScale;
    }

    public void SetTransform(Transform HealthBarTransform)
    {
        healthBar = HealthBarTransform;
    }
}
