using UnityEngine;


//Waypoints class, on commencement of a game/level will initialise a list of waypoints for units to move through.
public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        //Debug.Log(transform.name);
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            //Debug.Log(points[i].name + " " + points[i].position);
        }
    }

    public Transform[] GetPoints()
    {
        return points;
    }
}