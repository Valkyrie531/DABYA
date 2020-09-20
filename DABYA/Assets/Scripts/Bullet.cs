using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script for Bullet of Tower.
 * Setup movement to the target and destory the monster.
 * 
 */
public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 60f;

    public void Seek(Transform _target)
    {
        target = _target;
    }



    void Update ()
    {
        if (target == null)
        {
           
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Debug.Log("We Hit something!"); 
    }


}