using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script for Tower setting to kill the monster by tracking as the Target. 
 * 
 */
public class Tower : MonoBehaviour
{
    private Transform target;

    [Header("Tower Setting")]
    public float range = 5f;
    private float timeBtwShots;
    public float startTimeBtwShots;
    [Header("Unity Stuff")]
    public string enemyTag = "Enemy";
    public GameObject bullet;

    /* start game with updating target after each 0.1s.
     * 
     */

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);

        timeBtwShots = startTimeBtwShots;
    }

    /* locate the nearest monster as the target.
    *  When muliple monsters come into the tower range , aim the nearest monster.
    */
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //looping each monster as tag enemy for distance.

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }


        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        

    }



    /* 
    *  
    */
    void Update()
    {
        if (target == null)
        {
            return;
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
  
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    } 

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
