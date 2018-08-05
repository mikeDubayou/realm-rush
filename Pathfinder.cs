using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pathfinder : MonoBehaviour
{
    #region Starting Variables

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> q = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;

    Vector2Int[] directions =
        {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
        };

    #endregion
    //--------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------
    void Start ()
	{
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbors();
    }

    private void Pathfind()
    {
        q.Enqueue(startWaypoint);
        while (q.Count > 0 && isRunning)
        {
            Waypoint searchCenter = q.Dequeue();
            print("Searching from " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;

        }
        print("Finished pathfinding?!?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }

    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbor.SetTopColor(Color.blue);        //TODO remove later
            q.Enqueue(neighbor);
            print("Queueing " + neighbor);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block @ " + gridPos);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

}
