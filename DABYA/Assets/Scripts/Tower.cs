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
    private float fireRate= 1f;
    public float fireCountdown= 0f;
    [Header("Unity Stuff")]
    public string enemyTag = "Enemy";
    public GameObject bullet;
    public GameObject bulletPrefab;
    public Transform firePoint;

    /* start game with updating target after each 0.1s.
     * 
     */

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);

        
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

        foreach (GameObject enemy in enemies)
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
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
       GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
