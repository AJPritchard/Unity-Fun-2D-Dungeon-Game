using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NpcMana : MonoBehaviour
{
    private int MaxMana = 100;
    public float currentMana;


    private readonly GameObject NPC;
    public Transform ManaBar;

    private readonly float ManaBarMaxSize;

    /**
     * Creates the NPCMana with and sets its NPC
     */
    public NpcMana(GameObject NPC)
    {
        currentMana = MaxMana;

        this.NPC = NPC;

        AdjustManaBar();
    }

    /**
    * Creates the NPCMana with and sets its NPC and its MaxMana
    */
    public NpcMana(GameObject NPC, int MaxMana)
    {
        this.MaxMana = MaxMana;
        currentMana = MaxMana;

        ManaBarMaxSize = ManaBar.localScale.x;

        this.NPC = NPC;
        AdjustManaBar();
    }

    /**
    * Creates the NPCMAna with and sets its NPC and its MaxMana and its manabars transform
    */
    public NpcMana(GameObject NPC, int MaxMana, Transform manaBarTransform)
    {
        this.MaxMana = MaxMana;
        currentMana = MaxMana;

        ManaBar = manaBarTransform;
        ManaBarMaxSize = ManaBar.localScale.x;

        this.NPC = NPC;
        AdjustManaBar();
    }

    public void AddMana(float mana)
    {
        currentMana += mana;

        if(currentMana > MaxMana)
        {
            currentMana = MaxMana;
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

    public void SetMaxMana(int maxMana)
    {
        MaxMana = maxMana;

        AdjustManaBar();
    }

    public float GetMaxMana()
    {
        return MaxMana;
    }

    public void SetTransform(Transform manaBar)
    {
        ManaBar = manaBar;
    }

    /**
     * Adjusts the mana bar to the correct size depending on how much mana you have
     * 
     */
    private void AdjustManaBar()
    {

        Vector3 localScale = ManaBar.localScale;
        float percOfMana = currentMana / MaxMana;
        localScale.x = ManaBarMaxSize * percOfMana;
        ManaBar.localScale = localScale;
    }
}
