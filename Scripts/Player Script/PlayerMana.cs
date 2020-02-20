using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public float currentMana;

    private readonly GameObject Player;
    public Transform ManaBar;

    private readonly float ManaBarMaxSize;

    /**
     * Creates the Playermana with and sets its player
     */
    public PlayerMana(GameObject player)
    {
        currentMana = PlayerStats.MaxMana;
        
        this.Player = player;

        ManaBar = GameObject.Find("Mana Bar").transform;
        ManaBarMaxSize = ManaBar.localScale.x;

        AdjustManaBar();
    }

    public void AddMana(float mana)
    {
        currentMana += mana;

        if (currentMana > PlayerStats.MaxMana)
        {
            currentMana = PlayerStats.MaxMana;
        }

        AdjustManaBar();
    }

    public void UseMana(float mana)
    {
        currentMana -= mana;

        AdjustManaBar();
    }

    public float GetMana()
    {
        return currentMana;
    }

    public void SetTransform(Transform manaBar)
    {
        ManaBar = manaBar;
    }

    /**
     * Adjusts the mana bar to the correct size depending on how much mana you have
     * 
     */
    public void AdjustManaBar()
    {
        Vector3 localScale = ManaBar.localScale;
        float percOfMana = currentMana / PlayerStats.MaxMana;
        localScale.x = ManaBarMaxSize * percOfMana;
        ManaBar.localScale = localScale;
    }
}
