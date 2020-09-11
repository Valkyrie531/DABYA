using System.Collections;
using System.Collections.Generic;
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

    private Monster monster;

    /*  Initialises monster as the monster this script is controlling
     *  and target as the first waypoint in the list.
     */
    void Start()
    {
        monster = GetComponent<Monster>();

        target = Waypoints.points[waypointIndex];
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

        if(Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        //monster.speed = monster.speed;
    }

    /*Locates next waypoint and sets it as movement target, will also
     * identify if final waypoint has been reached.
     */
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    /*Destroys monster game object once it reaches the final way-point. 
     * Will need to be updated in the future once throne/win condition 
     * is introduced.
     */
    void EndPath()
    {
        Destroy(gameObject);
    }
}
