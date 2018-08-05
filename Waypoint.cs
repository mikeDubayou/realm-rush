using UnityEngine;

public class Waypoint : MonoBehaviour 
{

    #region Starting Variables

    public bool isExplored = false;
    Vector2Int gridPos;
    const int gridSize = 10;


    #endregion
    //--------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMesh = transform.Find("Up").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }
}
