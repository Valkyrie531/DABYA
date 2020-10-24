using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMonster : Monster
{
    public SpeedMonster()
    {
        healthFactor = 1.5f;
        speedFactor = 0.5f;
        startDamage = 3;
        startHealth = 75;
        startSpeed = 12.5f;

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
        speed = startSpeed + speedUpgrade + permaSpeedUpgrade;
        health = startHealth + healthUpgrade + permaHealthUpgrade;
        baseDamage = startDamage + permaDamageUpgrade;
    }

    //Left in in case update is needed for some reason in the future.
    void Update()
    {

    }
}
