using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    public bool Breakable = true;

    public void BlowUp()
    {
        if(Breakable)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void BlowUp(float timer)
    {
        if (Breakable)
        {
            GameObject.Destroy(gameObject, timer);
        }
    }
}
