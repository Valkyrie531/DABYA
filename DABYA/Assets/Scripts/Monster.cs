using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    private LevelManager levelManager;

    private int monsterDeathValue = 10; 
    private readonly int monsterSpawnValue = (int)Math.Floor(40 * DifficultySelection.spendGoldModifier);
    private int baseUpgradeCost = 20;
    protected float healthCostFactor = 1;
    protected float speedCostFactor = 1;

    protected float startSpeed = 10f;
    public float speed;
    public float speedUpgrade = 0f;
    protected static float permaSpeedUpgrade = 0f;
    protected float speedFactor = 1f;

    protected float startHealth = 100;
    public float health;
    public float healthUpgrade = 0f;
    protected static float permaHealthUpgrade = 0f;
    protected float healthFactor = 1f;

    protected int startDamage = 2;
    protected static int permaDamageUpgrade = 0;
    public int baseDamage;

    //Future-proofing for when health bars are to be added.
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;
    private bool isSlow = false;

    //As monster is spawned set health and speed to our pre-set values
    //the speed and health upgrades are for when clones are made, they enable the upgrading of monsters by adding how much the stat was
    //upgraded by to the starting speed/health
    void Start()
    {
        speed = startSpeed + speedUpgrade + permaSpeedUpgrade;
        health = startHealth + healthUpgrade + permaHealthUpgrade;
        baseDamage = startDamage + permaDamageUpgrade;
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

        //healthBar.fillAmount = health / startHealth;

        Debug.Log("Got hit - " + health.ToString());

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    //Destroys the monster game object, killing the monster.
    void Die()
    {
        isDead = true;
        levelManager.playerMoneyAdjustor(monsterDeathValue);
        Destroy(gameObject);
    }

    /* 
     * Damages the base depending on the monsters damage to the base, passed
     * though to the level manager from monster
     * and then destroys the monster
     */
    public void DamageBase()
    {
        levelManager.levelSpawner.BaseHitFor(baseDamage);
        levelManager.playerMoneyAdjustor(monsterDeathValue);
        Destroy(gameObject);
    }

    /* Slows down monster movement speed.
     * 
     */
    public void Slow(float duration)
    {
        if (!isSlow)
        {
            isSlow = true;
            speed *= 0.5f;
            StartCoroutine(SlowTime(duration));
        }
    }

    /* Coroutine to check how long monster is slowed for.
     * 
     */
    public IEnumerator SlowTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed *= 2;
        isSlow = false;
    }

    //Allows for the level manager to be set for the monster for when it is spawned
    public void SetLevelManager(LevelManager manager)
    {
        levelManager = manager;
    }

    public int GetHealthCost()
    {
        return (int)Math.Floor(baseUpgradeCost * healthCostFactor);
    }

    public int GetSpeedCost()
    {
        return (int)Math.Floor(baseUpgradeCost * speedCostFactor);
    }

    public void UpgradeSpeed()//upgrades the health of the monster by increasing the value of the speedUpgrade variable
    {
        speedUpgrade = speedUpgrade + 0.1f;
    }

    public void UpgradeHealth()//upgrades the health of the monster by increasing the value of the healthUpgrade variable
    {
        healthUpgrade = healthUpgrade + 10;
    }

    public void DowngradeHealth()//downgrades the health of the monster by decreasing the value of the healthUpgrade variable
    {
        if (!minHealth())
        {
            healthUpgrade = healthUpgrade - 10;
        }
    }

    public void DowngradeSpeed()//downgrades the speed of the monster by decreasing the value of the speedUpgrade variable
    {
        if (!minSpeed())
        {
            speedUpgrade = speedUpgrade - 0.1f;
        }
    }

    public void PremaUpgradeSpeed()
    {
        permaSpeedUpgrade += 0.1f;
    }

    public void PremaUpgradeHealth()
    {
        Debug.Log("yeet");
        permaHealthUpgrade += 10f;
    }

    public void PremaUpgradeDamage()
    {
        permaDamageUpgrade += 1;
    }

    public float GetUpgradedSpeed()
    {
        return startSpeed + speedUpgrade + permaSpeedUpgrade;
    }

    public float GetUpgradedHealth()
    {
        return startHealth + healthUpgrade + permaHealthUpgrade;
    }

    public int GetUpgradedDamage()
    {
        return startDamage + permaDamageUpgrade;
    }

    public int getSpawnValue()
    {
        return monsterSpawnValue;
    }

   /* public void Reset()//since the prefab is altered, the values for the upgrad evariables need to be reset to default (0)
   {
        speedUpgrade = 0f;
        healthUpgrade = 0f;
   */ 

    public bool minHealth()
    {
        if (healthUpgrade > 0.0f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool minSpeed()
    {
        if (speedUpgrade > 0.05f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
