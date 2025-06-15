using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - CityBuildingSystem.GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        Vector3 position = CityBuildingSystem.GetMouseWorldPosition() + offset;
        transform.position = CityBuildingSystem.current.SnapCoordinateToGrid(position);
    }

    
}
