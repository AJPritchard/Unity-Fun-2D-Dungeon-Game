using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[] Structures;
    public bool MustBeEmpty = true; // To force which one is selected

    // Start is called before the first frame update
    void Start()
    {

        PlaceTile();

        if (!MustBeEmpty)
        {
            PlaceStructure();
        }
    }

    private void PlaceTile()
    {
        int rand = 0;
        rand = Random.Range(0, tiles.Length);

        GameObject instance = Instantiate(tiles[rand], transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
    }

    private void PlaceStructure()
    {
        int rand = 0;
        rand = Random.Range(0, Structures.Length);

        Vector3 posTemp = transform.position;
        posTemp.z = 0;

        GameObject instance = Instantiate(Structures[rand], posTemp, Quaternion.identity);
        instance.transform.SetParent(transform);
    }
}
