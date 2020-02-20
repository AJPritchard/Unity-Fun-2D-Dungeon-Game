using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    private GameObject[] Targets;

    public float speed;
    public NpcHealth health;
    public float damage = 15;
    public float attackSpeed;

    private void Start()
    {
        Targets = GameObject.FindGameObjectsWithTag("Player");
        health = new NpcHealth(gameObject, 100);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Targets[0].transform.position, speed * Time.deltaTime);

        if(health.isDead)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health.TakeDamage(damage);
    }

    public void DealDamage(GameObject target)
    {
        target.GetComponent<PlayerController>().GetHealth().TakeDamage(damage);
        //Debug.Log("Hit! Health Left: " + target.GetComponent<PlayerController>().GetHealth().currentHealth);
    }

    public NpcHealth GetHealth()
    {
        return health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage(collision.gameObject);
        }
    }
}
