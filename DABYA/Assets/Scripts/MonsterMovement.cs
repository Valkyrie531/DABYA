using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class MonsterMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Monster monster;

    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponent<Monster>();

        target = Waypoints.points[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * monster.speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        monster.speed = monster.startSpeed;
    }

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

    void EndPath()
    {
        Destroy(gameObject);
    }
}
