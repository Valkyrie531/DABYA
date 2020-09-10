using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public LevelManager levelManager;

    public int startHealth = 20;

    [HideInInspector]
    public int health;


    public void BaseDamaged(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            BaseDestroyed();
        }
    }

    public void BaseDestroyed()
    {
        levelManager.LevelSuccess();
    }

    void Start()
    {
        health = startHealth;
    }
}
