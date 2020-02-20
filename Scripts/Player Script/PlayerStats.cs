using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float MaxHealth = 100;
    public static float MaxMana = 100;
    public static float ManaRegen = 5;

    public void AdjustMaxHealth(float newMax)
    {
        MaxHealth = newMax;
        PlayerController.health.AdjustHealthBar();
    }

    public void AdjustMaxMana(float newMax)
    {
        MaxMana = newMax;
        PlayerController.mana.AdjustManaBar();
    }

    public void AdjustManaRegen(float newRegen)
    {
        ManaRegen = newRegen;
    }
}
