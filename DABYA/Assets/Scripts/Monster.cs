using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    private float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    private float startHealth = 100;
    public float health;

    private int monsterValue = 10;

    //Future-proofing for when health bars are to be added.
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    //As monster is spawned set health and speed to our pre-set values
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    /*
     * Input: float damage: the amount of damage the monster will take.
     * 
     * Inflicts damage upon the monster and if enough damage is inflicted
     * kills the monster.
     */
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    //Destroys the monster game object, killing the monster.
    void Die()
    {
        Player.Money += monsterValue;

        isDead = true;

        Destroy(gameObject);
    }

    //Left in in case update is needed for some reason in the future.
    void Update()
    {
        
    }
}
