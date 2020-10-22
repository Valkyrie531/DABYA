using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    public LevelManager levelManager;
    public PermaUpgrades upgrades;

    public int startHealth = 20;

    [HideInInspector]
    private int health;
    private bool destroyed = false;

    /*
     * damage the base depending on the damage the monster does, passed
     * through by the level manager to the base
     * if health fall below 1 then the base is considered destroyed
     */
    public void BaseDamaged(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            health = 0;
            BaseDestroyed();
        }
    }

    /*
     * set the base to destroyed and call for the level completion
     * popup to show
     */
    public void BaseDestroyed()
    {
        destroyed = true;
        levelManager.LevelCompleted();
    }

    //return the heath of the base
    public int GetHealth()
    {
        return health;
    }

    //return whether the base is destoryed or not
    public bool IsDestroyed()
    {
        return destroyed;
    }

    //when the base is first created
    void Start()
    {
        health = (int)Math.Floor(startHealth * DifficultySelection.baseHealthModifier);
        health -= upgrades.GetBaseHealthDowngrade();
    }
}
