using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankMonster : Monster
{
    public TankMonster()
    {
        healthFactor = 0.5f;
        speedFactor = 1.5f;
        startDamage = 1;
        startHealth = 150;
        startSpeed = 7.5f;

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
