using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Script used for monster movement. Has been placed in a separate
 * script to the monster class to increase modularity.
 */

[RequireComponent(typeof(Monster))]
public class MonsterMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;
    private int waypointSelector = 1;
    private bool alternatePaths = false;
    private Waypoints waypointStartPath;
    private Waypoints waypointsAlternatePath;
    private Waypoints currentWaypointPath;
    private Waypoints[] waypointsList;

    private Monster monster;

    /*  Initialises monster as the monster this script is controlling
     *  and target as the first waypoint in the list.
     */
    void Start()
    {
        monster = GetComponent<Monster>();

        waypointsList = FindObjectsOfType<Waypoints>();

        if (waypointsList.Length == 1)
            waypointStartPath = FindObjectsOfType<Waypoints>()[0];
        else
            for (int i = 0; i < waypointsList.Length; i++)
            {
                if (waypointsList[i].name == "WaypointsStartPath")
                    currentWaypointPath = waypointsList[i];
                else
                    i++;
            }

        target = currentWaypointPath.GetPoints()[waypointIndex];

        for (int i = 0; i < waypointsList.Length; i++)
        {
            Debug.Log(waypointsList[i].name);
            for (int j = 0; j < waypointsList[i].GetPoints().Length; j++)
                Debug.Log(waypointsList[i].GetPoints()[j].name);
        }
        //if statement where if WaypointsPath1 or WaypointsPath2 exist then alternatePaths = true
        if(GameObject.Find("WaypointsPath1"))
        {
            if (waypointsList[0].name != "WaypointsStartPath")
                waypointsAlternatePath = waypointsList[0];
            else
                waypointsAlternatePath = waypointsList[1];
            alternatePaths = true;
        }
    }

    /* Main driver for monster movement. 
     * Moves the monster - hopefully smoothly and once it gets close
     * enough to a waypoint (0.2 in this case) it will attempt to find
     * the next waypoint to move to.
     */
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * monster.speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    /*Locates next waypoint and sets it as movement target, will also
     * identify if final waypoint has been reached. If final waypoint is
     * reached checks to see if alernate paths are available and if so
     * sets alternate path as new target.
     */
    void GetNextWaypoint()
    {
        if (waypointIndex >= currentWaypointPath.GetPoints().Length - 1)
        {
            if (alternatePaths == true)
            {
                //ConfirmWaypointDirection();
                ChooseNewPath(waypointSelector);
            }
            else
            {
                EndPath();
                return;
            }
        }

        waypointIndex++; 
        target = currentWaypointPath.GetPoints()[waypointIndex];
    }

    void ChooseNewPath(int pathSelected)
    {
        string wpPathString = "WaypointsPath" + pathSelected.ToString();
        for (int i = 0; i < waypointsList.Length; i++)
        {
            if (waypointsList[i].name == wpPathString)
                currentWaypointPath = waypointsList[i];
        }
        for (int i = 0; i < currentWaypointPath.GetPoints().Length; i++)
        waypointIndex = 0;
        alternatePaths = false;
    }

    /*Destroys monster game object once it reaches the final way-point
     * and damages the base
     * 
     */
    void EndPath()
    {
        monster.DamageBase();
        Destroy(gameObject);
    }
}
