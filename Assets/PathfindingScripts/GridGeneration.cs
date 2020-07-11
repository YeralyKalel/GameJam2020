using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration : MonoBehaviour
{
    #region Singleton
    public static GridGeneration instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [HideInInspector]
    public Pathfinding pathfinding;

    //Size of Grid
    public int gridWidth;
    public int gridHeight;
    public int cellSize;

    bool gridGenerated = false;

    Grid<PathNode> grid;

    private List<PathNode> path;
    private bool pathComplete;


    private void Update()
    {
        if (!gridGenerated)
        {
            pathfinding = new Pathfinding(gridWidth, gridHeight, cellSize);
            grid = pathfinding.GetGrid();


            //for (int i = 0; i < grid.GetWidth(); i++)   //i represents x, p represents y because i cant use x and y here
            //{
            //    for (int p = 0; p < grid.GetHeight(); p++)
            //    {
            //        int cellSize = Mathf.RoundToInt(grid.cellSize);
            //        SpawnTile(i, p);
            //    }

            //}

            gridGenerated = true;
        }
    }

    //public GameObject SpawnTile(int x, int y)
    //{
    //    GameObject objectSpawned = Instantiate(tile, new Vector3(x + 0.5f, y + 0.5f, 0), Quaternion.identity, tileParent.transform);
    //    return objectSpawned;
    //}

    //This may be useful in the future in order to spawn the tiles on the grid so that there are actual gameobjects (if you are confused just ask me (ollie))
}
