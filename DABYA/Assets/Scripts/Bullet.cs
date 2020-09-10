using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Transform bullet;
    private Vector2 bulletMovement;
    private GameObject enemy;


    void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Enemy").transform;
        bulletMovement = new Vector2(bullet.position.x, bullet.position.y);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, bullet.position, speed * Time.deltaTime);
    }
}
