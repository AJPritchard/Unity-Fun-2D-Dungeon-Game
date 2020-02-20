using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] objects;
    public float spawnPerc;

    // Start is called before the first frame update
    void Start()
    {

        if (Random.Range(0, 100) <= spawnPerc)
        {
            int rand = Random.Range(0, objects.Length);
            GameObject instance = Instantiate(objects[rand], transform.position, Quaternion.identity);
            instance.transform.SetParent(transform);
        }
    }
}
