using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/* This code is the skeleton for the city building system in the game. You place buildings on rectangular tiles
 * which will be designated for that particular building.
 * 
 * IMPORTANT: We cellswizzled the grid/tilemap to be XZY, so the y-coordinate internally is height, while Z now dictates 3D.
 * This is not shared by the actual unity 3D stuff, so just beware.
 */
public class CityBuildingSystem : MonoBehaviour
{
    public static CityBuildingSystem current; // Singleton building system

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase usedTile;

    // We'll need to make a lot of prefabs...
    public GameObject prefab1; // House
    public GameObject prefab2; // Factory
    public GameObject prefab3; // FactoryLarge

    private PlaceableObject objectToPlace;

    #region Unity methods

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) // key B for now. look into InputSystem.actions.FindAction("Move") later.
        {
            InitializeObject(prefab1);
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            InitializeObject(prefab2);
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeObject(prefab3);
        }

        if (!objectToPlace)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanBePlaced(objectToPlace))
            {
                objectToPlace.Place();
                Vector3Int startPosition = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(startPosition, objectToPlace.Size);
            } else
            {
                Destroy(objectToPlace.gameObject);
            }
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(objectToPlace.gameObject);
        }
        // Later we want to put all of this into a menu!
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit point: " + hit.point);
            return hit.point;
        }
        Debug.LogWarning("Raycast didn't hit anything.");
        return Vector3.zero;
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] GetTileBase(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;
        
        // Iterate through each tile in the tilemap and store them in the TileBase[] array
        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int position = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(position);
            counter++;
        }

        return array;
    }

    #endregion

    #region Placing Buildings

    public void InitializeObject(GameObject buildingPrefab)
    {
        Vector3 mousePosition = CityBuildingSystem.GetMouseWorldPosition();
        Vector3 position = SnapCoordinateToGrid(mousePosition);
        // Note: When we instantiate more buildings we'll need some way to make all of them exist directly on top of the platforms. Hm.

        // Gonna be so fr I hate this code but I don't think there's literally anything better

        GameObject obj;
        obj = Instantiate(buildingPrefab, position, Quaternion.identity);
        

        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();

    }

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = new Vector3Int(placeableObject.Size.x + 1, placeableObject.Size.y + 1, placeableObject.Size.z);

        TileBase[] baseArray = GetTileBase(area, mainTilemap);

        foreach (var b in baseArray)
        {
            if (b == usedTile)
            {
                return false;
            }
        }

        return true;
    }

    public void TakeArea(Vector3Int startPosition, Vector3Int size)
    {
        mainTilemap.BoxFill(startPosition, usedTile, startPosition.x,
                            startPosition.y, startPosition.x + size.x
                                           , startPosition.y + size.y);

    }

    #endregion

}
