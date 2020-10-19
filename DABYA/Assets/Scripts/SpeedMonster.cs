using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMonster : Monster
{
    private readonly float startSpeed = 15f; // changes the start speed from the defaullt 10 to 15

    private readonly float startHealth = 50; // changes the starting health from the default 100 to 50

    private readonly int startDamage = 1;

    public SpeedMonster()
    {
        healthFactor = 1.5f;
        speedFactor = 0.5f;

        healthCostFactor = DifficultySelection.spendGoldModifier * healthFactor;
        speedCostFactor = DifficultySelection.spendGoldModifier * speedFactor;
    }

    //Future-proofing for when health bars are to be added.
//    [Header("Unity Stuff")]
//    public Image healthBar;
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
