using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour 
{

    #region Starting Varibles

    Waypoint wp;

    #endregion
    //--------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------

    private void Awake()
    {
        wp = GetComponent<Waypoint>();
    }

    void Update ()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = wp.GetGridSize();
        transform.position = new Vector3(
            wp.GetGridPos().x * gridSize, 
            0f, 
            wp.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh tm = GetComponentInChildren<TextMesh>();
        string labelText = wp.GetGridPos().x + ", " + wp.GetGridPos().y;
        tm.text = labelText;
        gameObject.name = labelText;
    }

}
