using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public const int ROOMLENGTH = 11;

    public Transform[] startingPositions;
    public GameObject[] RoomTypes;
    public GameObject[] WallTypes;
    public GameObject[] TileTypes;
    public GameObject[] RoomContentTypes;
    public int LevelWidth;
    public int LevelHeight;

    private GameObject[,] levelLayout; // (x, y)
    private GameObject parent;
    private GameObject borderParent;

    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        parent = new GameObject("Level Controller");
        borderParent = new GameObject("Border");

        borderParent.transform.SetParent(parent.transform);

        levelLayout = new GameObject[LevelWidth, LevelHeight];

        BuildBorder();
        BuildRooms();
        FillRooms();
        SpawnPlayer();
    }

    /**
     * Builds the border around the level 
     */
    private void BuildBorder()
    {
        GameObject curWall;
        // Builds the top and bottom borders
        for (float x = -LevelWidth / 2 * ROOMLENGTH; x < LevelWidth / 2 * ROOMLENGTH + 1; x++)
        {
            curWall = Instantiate(WallTypes[Random.Range(0, WallTypes.Length)], new Vector3(x - 2, -LevelHeight / 2 * ROOMLENGTH - 2, 0), Quaternion.identity);
            curWall.transform.SetParent(borderParent.transform);
            curWall.GetComponent<Walls>().Breakable = false;

            curWall = Instantiate(WallTypes[Random.Range(0, WallTypes.Length)], new Vector3(x - 2, LevelHeight / 2 * ROOMLENGTH + 1 - 2, 0), Quaternion.identity);
            curWall.transform.SetParent(borderParent.transform);
            curWall.GetComponent<Walls>().Breakable = false;


        }
        // Builds the left and right side borders
        for (float y = -LevelHeight / 2 * ROOMLENGTH; y <= LevelHeight / 2 * ROOMLENGTH + 1; y++)
        {
            curWall = Instantiate(WallTypes[Random.Range(0, WallTypes.Length)], new Vector3(-LevelWidth / 2 * ROOMLENGTH - 2, y - 2, 0), Quaternion.identity);
            curWall.transform.SetParent(borderParent.transform);
            curWall.GetComponent<Walls>().Breakable = false;


            curWall = Instantiate(WallTypes[Random.Range(0, WallTypes.Length)], new Vector3(LevelWidth / 2 * ROOMLENGTH + 1 - 2, y - 2, 0), Quaternion.identity);
            curWall.transform.SetParent(borderParent.transform);
            curWall.GetComponent<Walls>().Breakable = false;

        }
    }

    /**
     * Builds the Rooms that make up the level
     */
    private void BuildRooms()
    {
        RoomScript curRS;

        for(int x = 0; x < LevelWidth; x++)
        {
            for(int y = 0; y < LevelHeight; y++)
            {

                //Debug.Log("(" + x + ", " + y + ")");

                levelLayout[x, y] = RoomTypes[Random.Range(0, RoomTypes.Length)];

                curRS = levelLayout[x, y].GetComponent<RoomScript>();
            }
        }

        int roomX;
        int roomY;
        GameObject temp;

        // Instantiate the Rooms in their correct locations
        for (int x = 0; x < LevelWidth; x++)
        {
            for (int y = 0; y < LevelHeight; y++)
            {

               // Debug.Log("(" + x + ", " + y + ")");


                roomX = x * ROOMLENGTH - LevelWidth / 2 * ROOMLENGTH;
                roomY = y * ROOMLENGTH - LevelHeight / 2 * ROOMLENGTH;


                temp = Instantiate(levelLayout[x, y], new Vector3(roomX + 4, roomY + 4, 0), Quaternion.identity);
                temp.transform.SetParent(transform);
                levelLayout[x, y] = temp;
            }
        }

    }

    /**
     * Places the tiles on the map
     */
    private void FillRooms()
    {

        int roomX;
        int roomY;
        GameObject temp;

        for (int x = 0; x < LevelWidth; x++)
        {
            for (int y = 0; y < LevelHeight; y++)
            {

                //Debug.Log("(" + x + ", " + y + ")");


                roomX = x * ROOMLENGTH - LevelWidth / 2 * ROOMLENGTH;
                roomY = y * ROOMLENGTH - LevelHeight / 2 * ROOMLENGTH;


                temp = Instantiate(RoomContentTypes[Random.Range(0, RoomContentTypes.Length)], new Vector3(roomX + 4, roomY + 4, 0), Quaternion.identity);
                temp.transform.SetParent(levelLayout[x,y].transform);
            }
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(player, new Vector3(0, 0, -1), Quaternion.Euler(0, 0, 0));
    }
}
