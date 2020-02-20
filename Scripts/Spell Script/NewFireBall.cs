using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFireBall : Spell
{
    private GameObject caster;
    private Vector3 dest;
    private Vector3 direction;

    public float explosionTime;
    private Animator animControl;
    private bool Exploding = false;


    private void Start()
    {
        animControl = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!Exploding)
        {
            if (Mathf.Abs((transform.position.x - dest.x)) < 1 && Mathf.Abs((transform.position.y - dest.y)) < 1)
            {
                Explode();
            }
            else
            {
                Vector3 newLoc = transform.position + direction * SpellData.FireballSpeed;
                transform.position = newLoc;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    public void SetCaster(GameObject caster)
    {
        this.caster = caster;
    }

    public void SetDest(Vector3 dest)
    {
        this.dest = dest;
        direction = (new Vector3(dest.x - transform.position.x, dest.y - transform.position.y, 0).normalized);
        //Debug.Log("Destination: " + dest + " Starting Point: " + transform.position + " Direction: " + direction);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Explode()
    {
        // Start Animation cycle
        Exploding = true;
        //Debug.Log("COLLISION");
        animControl.SetBool("Contact", true);
        AreaDamageEnemies(transform.position, SpellData.FireballExplosionRadius, SpellData.FireballDamage);
        Destroy(gameObject, explosionTime);
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(new Vector2(location.x, location.y), SpellData.FireballExplosionRadius);
        foreach (Collider2D col in objectsInRange)
        {
            GameObject impactedObject = col.gameObject;
            if (impactedObject != null && impactedObject.gameObject != caster)
            {
                if (impactedObject.CompareTag("Wall"))
                {

                    // linear falloff of effect
                    //float proximity = (location - enemy.transform.position).magnitude;
                    //float effect = 1 - (proximity / radius);


                    //enemy.ApplyDamage(damage * effect);

                    impactedObject.GetComponent<Walls>().BlowUp(explosionTime);
                }
                if (impactedObject.CompareTag("Enemy"))
                {
                    
                    impactedObject.GetComponent<ZombieScript>().GetHealth().TakeDamage(damage * (1 - ((location - impactedObject.transform.position).magnitude / radius)));
                }
                

            } 
        }
    }
}
