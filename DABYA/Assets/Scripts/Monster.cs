using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    private float startSpeed = 10f;
    public float speed;

    private float startHealth = 100;
    public float health;

    private int startDamage = 2;
    public int baseDamage;
    private GameObject levelManager;

    //Future-proofing for when health bars are to be added.
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    //As monster is spawned set health and speed to our pre-set values
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        baseDamage = startDamage;
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
        isDead = true;
        //TODO: remove magic number
        levelManager.GetComponent<LevelManager>().playerMoneyAdjustor(10);
        Destroy(gameObject);
    }

    /* 
     * Damages the base depending on the monsters damage to the base, passed
     * though to the level manager from monster
     * and then destroys the monster
     */
    public void DamageBase()
    {
        levelManager.GetComponent<LevelManager>().BaseHitFor(baseDamage);
        //TODO: remove magic number
        levelManager.GetComponent<LevelManager>().playerMoneyAdjustor(10);
        Destroy(gameObject);
    }

    //Allows for the level manager to be set for the monster for when it is spawned
    public void SetLevelManager(GameObject manager)
    {
        levelManager = manager;
    }

    //Left in in case update is needed for some reason in the future.
    void Update()
    {
        
    }
}
