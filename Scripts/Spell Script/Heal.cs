using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Spell
{
    public float TimeUntilDestroy;

    private void Awake()
    {
        GameObject.Destroy(gameObject, TimeUntilDestroy);
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 250) * Time.deltaTime);
    }
}
