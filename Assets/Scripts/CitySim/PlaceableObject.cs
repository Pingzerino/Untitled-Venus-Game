using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool Placed
    {
        get; private set;
    }
    public Vector3Int Size { get; private set; }
    private Vector3[] Vertices;

    private void GetColliderVertexPositionsLocal()
    {
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();
        Vertices = new Vector3[4];
        Vertices[0] = collider.center + new Vector3(-collider.size.x, -collider.size.y, -collider.size.z) * 0.5f;
        Vertices[1] = collider.center + new Vector3(collider.size.x, -collider.size.y, -collider.size.z) * 0.5f;
        Vertices[2] = collider.center + new Vector3(collider.size.x, -collider.size.y, collider.size.z) * 0.5f;
        Vertices[3] = collider.center + new Vector3(-collider.size.x, -collider.size.y, collider.size.z) * 0.5f;
    }

    private void CalculateSizeInCells()
    {
        Vector3Int[] vertices = new Vector3Int[Vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(Vertices[i]);
            vertices[i] = CityBuildingSystem.current.gridLayout.WorldToCell(worldPos);
        }

        Size = new Vector3Int(Math.Abs((vertices[0] - vertices[1]).x),
                              Math.Abs((vertices[0] - vertices[3]).y), 1);
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(Vertices[0]);
    }

    private void Start()
    {
        GetColliderVertexPositionsLocal();
        CalculateSizeInCells();
    }
    // This is virtual because we will override it eventually for varying buildings
    public virtual void Place()
    {
        ObjectDrag drag = gameObject.GetComponent<ObjectDrag>();
        Destroy(drag);

        Placed = true;

        // Invoke placement events
    }


}
