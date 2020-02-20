using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The Health Object used for all npcs
 */
 [System.Serializable]
public class NpcHealth
{

    private int MaxHealth = 100;
    public float currentHealth;
    public bool isDead = false;

    public GameObject NPC;
    public Transform healthBar;
    private readonly float HealthBarMaxSize;

    /**
     * NPC Health takes in the NPC object and sets its max health to 100
     */
    public NpcHealth(GameObject NPC)
    {
        this.NPC = NPC;
        currentHealth = MaxHealth;

        healthBar = NPC.transform.GetChild(0);
        HealthBarMaxSize = healthBar.localScale.x;

        AdjustHealthBar();
    }

    /**
     * NPC Health takes in the NPC object and a startingHealth which is max health
     */
    public NpcHealth(GameObject NPC, int StartingHealth)
    {
        this.NPC = NPC;
        this.MaxHealth = StartingHealth;
        currentHealth = StartingHealth;

        healthBar = NPC.transform.GetChild(0);
        HealthBarMaxSize = healthBar.localScale.x;

        AdjustHealthBar();
    }

    /**
 * NPC Health takes in the NPC object and a startingHealth which is max health and it sets the health bars transform
 */
    public NpcHealth(GameObject NPC, int StartingHealth, Transform healthBarTransform)
    {
        this.NPC = NPC;
        this.MaxHealth = StartingHealth;
        currentHealth = StartingHealth;

        healthBar = healthBarTransform;
        HealthBarMaxSize = healthBar.localScale.x;

        AdjustHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            //Debug.Log("DIED");
            isDead = true;
        }
        AdjustHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
        AdjustHealthBar();
    }

    public int GetStartingHealth()
    {
        return MaxHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.MaxHealth = maxHealth;
        AdjustHealthBar();
    }

    private void AdjustHealthBar()
    {
        
            Vector3 localScale = healthBar.localScale;
            float percOfHealth = currentHealth / MaxHealth;
            localScale.x = HealthBarMaxSize * percOfHealth;
            healthBar.localScale = localScale;
    }

    public void SetTransform(Transform HealthBarTransform)
    {
        healthBar = HealthBarTransform;
    }
}
