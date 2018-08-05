using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour 
{

	#region Starting Varibles
	
	[SerializeField] List<Waypoint> path;

    #endregion
    //--------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------------------------------------------------

    void Start ()
    {
        StartCoroutine(PrintAllWaypoints());
    }

    IEnumerator PrintAllWaypoints()
    {
        //print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            //print("Visiting block " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        //print("Ending patrol");
    }
}
