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
    protected Transform target;

    public float speed = 60f;
    private float damage;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void Update ()
    {
        if (target == null)
        {
            Destroy(gameObject);
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

    public virtual void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }

    public void Damage(Transform monster)
    {
        Monster m = monster.GetComponent<Monster>();

        if (m != null)
        {
            m.TakeDamage(damage);
        }

    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }


}