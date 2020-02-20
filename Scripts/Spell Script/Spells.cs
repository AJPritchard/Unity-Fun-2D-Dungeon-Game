using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public static GameObject[] AllSpells;
    public GameObject[] AllSpellsHelper;

    void Awake()
    {
        AllSpells = AllSpellsHelper;
    }

    public static void CastFireBall(GameObject caster, PlayerMana pm)
    {
        if (pm.currentMana > SpellData.FireballManaCost)
        {
            //...instantiating the Fireball
            GameObject bulletInstance = Instantiate(Spells.AllSpells[0], caster.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            NewFireBall fb = bulletInstance.GetComponent<NewFireBall>();
            fb.SetCaster(caster);
            fb.SetDest(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // Apply the mana cost
            pm.UseMana(SpellData.FireballManaCost);
        }
    }

    public static void CastTeleport(GameObject caster, PlayerMana pm)
    {

        if (pm.currentMana > SpellData.TeleportManaCost)
        {
            // Get the destination, which is where the mouse is currently located
            Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((destination - caster.transform.position).magnitude > SpellData.TeleportDistance)
            {
                return;
            }

            // set its z value to the correct -1
            destination.z = -1;

            // now we will instantiate the teleport animation
            GameObject teleportCurrent = Instantiate(Spells.AllSpells[1], caster.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));// FIX
            GameObject teleportDestination = Instantiate(Spells.AllSpells[1], destination, Quaternion.Euler(new Vector3(0, 0, 0)));

            // move the caster to that position
            caster.transform.position = destination;

            // Apply the mana cost
            pm.UseMana(SpellData.TeleportManaCost);
        }
    }


    public static void CastHeal(GameObject caster, PlayerMana pm, PlayerHealth ph)
    {

        if (pm.currentMana > SpellData.HealManaCost)
        {
            // now we will instantiate the heal animation
            GameObject healObj = Instantiate(Spells.AllSpells[2], caster.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            // Apply the mana cost
            pm.UseMana(SpellData.HealManaCost);
            ph.Heal(SpellData.HealAmount);
        }
    }

}
