using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankMonster : Monster
{
    private readonly float startSpeed = 5f; // changes the start speed from the defaullt 10 to 5

    private readonly float startHealth = 200; // changes the starting health from the default 100 to 200

    private readonly int startDamage = 3;

    public TankMonster()
    {
        healthFactor = 0.5f;
        speedFactor = 1.5f;

        healthCostFactor = DifficultySelection.spendGoldModifier * healthFactor;
        speedCostFactor = DifficultySelection.spendGoldModifier * speedFactor;
    }

    //Future-proofing for when health bars are to be added.
    //   [Header("Unity Stuff")]
    //   public Image healthBar;
    //leaving  this in but will probably remove it as the default monster should cover it


    //As monster is spawned set health and speed to our pre-set values
    void Start()
    {
        speed = startSpeed + speedUpgrade;
        health = startHealth + healthUpgrade;
        baseDamage = startDamage;
    }

    //Left in in case update is needed for some reason in the future.
    void Update()
    {

    }
}
