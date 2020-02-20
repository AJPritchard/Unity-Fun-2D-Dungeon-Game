using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellData : MonoBehaviour
{
    // Fireball Information
    public static float FireballDamage = 10;
    public static float FireballExplosionRadius = 1.5f;
    public static float FireballSpeed = 0.1f;
    public static float FireballManaCost = 30;

    // Teleport Information
    public static float TeleportDistance = 15;
    public static float TeleportManaCost = 75;

    // Heal Information
    public static float HealAmount = 20;
    public static float HealManaCost = 30;

    public void AdjustFireballDamage(float newDamage)
    {
        FireballDamage = newDamage;
    }

    public void AdjustFireballSpeed(float newSpeed)
    {
        FireballSpeed = newSpeed;
    }

    public void AdjustFireballExplosionRadius(float newRadius)
    {
        FireballExplosionRadius = newRadius;
    }

    public void AdjustTeleportDistance(float newDistance)
    {
        TeleportDistance = newDistance;
    }

    public void AdjustHealAmount(float newAmount)
    {
        HealAmount = newAmount;
    }

    public void AdjustFireballManaCost(float newCost)
    {
        FireballManaCost = newCost;
    }

    public void AdjustTeleportManaCost(float newCost)
    {
        TeleportManaCost = newCost;
    }

    public void AdjustHealManaCost(float newCost)
    {
        HealManaCost = newCost;
    }
}
