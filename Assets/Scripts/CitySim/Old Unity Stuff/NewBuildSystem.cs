/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBuildSystem : MonoBehaviour
{
    private GridXZ<GridObject> grid;


    void Awake()
    {
        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize = 1f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int z));

    }

    public class GridObject
    {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/
