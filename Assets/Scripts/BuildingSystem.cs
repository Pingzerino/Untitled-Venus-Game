using System.Collections;
using System.Collections.generic;
using UnityEngine;


public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance; // Singleton building system

    private GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase whiteTile;

    // We'll need to make a lot of prefabs...
    public GameObject prefab1; // House
    public GameObject prefab2; // Road

    private placeableObject objectToPlace;

    #region Unity methods

    private void Awake()
    {
        instance = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) // key B for now. look into InputSystem.actions.FindAction("Move") later.
        {
            InitializeWithObject(prefab1);
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            InitializeWithObject(prefab2);
        }
        // Later we want to put all of this into a MENU!
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    public static Vector3 SnapCoordianteToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    #endregion

    #region Placing Buildings

    public void InitializeObject(GameObject buildingPrefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj;
        obj = Instantiate(buildingPrefab, position, Quaternion.identity);

        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();

    }

    #endregion

}
