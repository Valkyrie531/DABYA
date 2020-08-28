using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Waypoints class, on commencement of a game/level will initialise a list of waypoints for units to move through.
public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
