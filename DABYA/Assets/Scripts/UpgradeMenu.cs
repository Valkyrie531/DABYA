using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Player levelPlayer;
    public GoldNotice goldError;
    public Monster monster;
    public SpeedMonster speedMonster;
    public TankMonster tankMonster;
    private bool minReached;

    public GameObject upgradeMenuUI;
    private decimal defaultMonSpeed = 10;
    public Text defaultMonSpeedTxt;
    private int defaultMonHealth= 100;
    public Text defaultMonHealthTxt;
    private decimal speedMonSpeed = 15;
    public Text speedMonSpeedTxt;
    private int speedMonHealth = 50;
    public Text speedMonHealthTxt;
    private decimal tankMonSpeed = 5;
    public Text tankMonSpeedTxt;
    private int tankMonHealth = 200;
    public Text tankMonHealthTxt;
    
    //speed upgrade values and text for all monsters
    [HideInInspector]
    public int defaultSpeedUpgrade = 20;
    public Text defaultSpeedUpgradeTxt;
    [HideInInspector]
    public int defaultSpeedDowngrade = 0;
    public Text defaultSpeedDowngradeTxt;
    [HideInInspector]
    public int speedSpeedUpgrade = 10;
    public Text speedSpeedUpgradeTxt;
    [HideInInspector]
    public int speedSpeedDowngrade = 0;
    public Text speedSpeedDowngradeTxt;
    [HideInInspector]
    public int tankSpeedUpgrade = 30;
    public Text tankSpeedUpgradeTxt;
    [HideInInspector]
    public int tankSpeedDowngrade = 0;
    public Text tankSpeedDowngradeTxt;

    //health upgrade values and text for all monsters
    [HideInInspector]
    public int defaultHealthUpgrade = 20;
    public Text defaultHealthUpgradeTxt;
    [HideInInspector]
    public int defaultHealthDowngrade = 0;
    public Text defaultHealthDowngradeTxt;
    [HideInInspector]
    public int speedHealthUpgrade = 30;
    public Text speedHealthUpgradeTxt;
    [HideInInspector]
    public int speedHealthDowngrade = 0;
    public Text speedHealthDowngradeTxt;
    [HideInInspector]
    public int tankHealthUpgrade = 10;
    public Text tankHealthUpgradeTxt;
    [HideInInspector]
    public int tankHealthDowngrade = 0;
    public Text tankHealthDowngradeTxt;

    private float upgradeCostFactor = 1.5f;

    public bool OpenUpgrades ()
    {
        upgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        return true;
    }

    public void Play()
    {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Start()
    {
        defaultSpeedUpgradeTxt.text = defaultSpeedUpgrade.ToString() + "g";
        defaultSpeedDowngradeTxt.text = defaultSpeedDowngrade.ToString() + "g";
        defaultHealthUpgradeTxt.text = defaultHealthUpgrade.ToString() + "g";
        defaultHealthDowngradeTxt.text = defaultHealthDowngrade.ToString() + "g";
        speedSpeedUpgradeTxt.text = speedSpeedUpgrade.ToString() + "g";
        speedSpeedDowngradeTxt.text = speedSpeedDowngrade.ToString() + "g";
        speedHealthUpgradeTxt.text = speedHealthUpgrade.ToString() + "g";
        speedHealthDowngradeTxt.text = speedHealthDowngrade.ToString() + "g";
        tankSpeedUpgradeTxt.text = tankSpeedUpgrade.ToString() + "g";
        tankSpeedDowngradeTxt.text = tankSpeedDowngrade.ToString() + "g";
        tankHealthUpgradeTxt.text = tankHealthUpgrade.ToString() + "g";
        tankHealthDowngradeTxt.text = tankHealthDowngrade.ToString() + "g";
    }

    //the following similarly name functions change the text to be the same as the value of the stats
    public void IncreaseDefaultMonSpeed()
    {
        if (CheckMoney(defaultSpeedUpgrade))
        {
            monster.UpgradeSpeed();
            defaultMonSpeed += 0.1m;
            defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
            UpdateCost("IDMS", false);
        }
    }

    public void DecreaseDefaultMonSpeed()
    {
        if (!monster.minSpeed())
        {
            monster.DowngradeSpeed();
            defaultMonSpeed -= 0.1m;
            defaultMonSpeedTxt.text = defaultMonSpeed.ToString();

            if (monster.minSpeed())
            {
                minReached = true;
            }
            else
            {
                minReached = false;
            }
            
            UpdateCost("DDMS", minReached);
        }
    }

    public void IncreaseDefaultMonHealth()
    {
        if (CheckMoney(defaultHealthUpgrade))
        {
            monster.UpgradeHealth();
            defaultMonHealth += 10;
            defaultMonHealthTxt.text = defaultMonHealth.ToString();
            UpdateCost("IDMH", false);
        }
    }

    public void DecreaseDefaultMonHealth()
    {
        if (!monster.minHealth())
        {
            monster.DowngradeHealth();
            defaultMonHealth -= 10;
            defaultMonHealthTxt.text = defaultMonHealth.ToString();

            if (monster.minHealth())
            {
                minReached = true;
            }
            else
            {
                minReached = false;
            }

            UpdateCost("DDMH", minReached);
        }
    }

    public void IncreaseSpeedMonSpeed()
    {
        if (CheckMoney(speedSpeedUpgrade))
        {
            speedMonster.UpgradeSpeed();
            speedMonSpeed += 0.1m;
            speedMonSpeedTxt.text = speedMonSpeed.ToString();
            UpdateCost("ISMS", false);
        }
    }

    public void DecreaseSpeedMonSpeed()
    {
        if (!speedMonster.minSpeed())
        {
            speedMonster.DowngradeSpeed();
            speedMonSpeed -= 0.1m;
            speedMonSpeedTxt.text = speedMonSpeed.ToString();

            if (speedMonster.minSpeed())
            {
                minReached = true;
            }
            else
            {
                minReached = false;
            }

            UpdateCost("DSMS", minReached);
        }
    }

    public void IncreaseSpeedMonHealth()
    {
        if (CheckMoney(speedHealthUpgrade))
        {
            speedMonster.UpgradeHealth();
            speedMonHealth += 10;
            speedMonHealthTxt.text = speedMonHealth.ToString();
            UpdateCost("ISMH", false);
        }
    }

    public void DecreaseSpeedMonHealth()
    {
        if (!speedMonster.minHealth())
        {
            speedMonster.DowngradeHealth();
            speedMonHealth -= 10;
            speedMonHealthTxt.text = speedMonHealth.ToString();

            if (speedMonster.minHealth())
            {
                minReached = true;
            }
            else
            {
                minReached = false;
            }

            UpdateCost("DSMH", minReached);
        }
    }

    public void IncreaseTankMonSpeed()
    {
        if (CheckMoney(tankSpeedUpgrade))
        {
            tankMonster.UpgradeSpeed();
            tankMonSpeed += 0.1m;
            tankMonSpeedTxt.text = tankMonSpeed.ToString();
            UpdateCost("ITMS", false);
        }
    }

    public void DecreaseTankMonSpeed()
    {
        if (!tankMonster.minSpeed())
        {
            tankMonster.DowngradeSpeed();
            tankMonSpeed -= 0.1m;
            tankMonSpeedTxt.text = tankMonSpeed.ToString();

            if (tankMonster.minSpeed())
            {
                minReached = true;
            }
            else
            {
                minReached = false;
            }

            UpdateCost("DTMS", minReached);
        }
    }

    public void IncreaseTankMonHealth()
    {
        if (CheckMoney(tankHealthUpgrade))
        {
            tankMonster.UpgradeHealth();
            tankMonHealth += 10;
            tankMonHealthTxt.text = tankMonHealth.ToString();
            UpdateCost("ITMH", false);
        }
    }

    public void DecreaseTankMonHealth()
    {
        if (!tankMonster.minHealth())
        {
            tankMonster.DowngradeHealth();
            tankMonHealth -= 10;
            tankMonHealthTxt.text = tankMonHealth.ToString();

            if (tankMonster.healthUpgrade <= 0)
            {
                minReached = true;
            }
            else
            {
                minReached = false;
            }

            UpdateCost("DTMH", minReached);
        }
    }

    public bool CheckMoney(int cost)
    {
        if (cost > levelPlayer.getMoney())
        {
            goldError.NotEnoughGoldPopUp();
            return false;
        }
        else
        {
            return true;
        }
    }

    void UpdateCost(string code, bool min)
    {
        switch (code)
        {
            case "IDMS":
                levelPlayer.spendMoney(defaultSpeedUpgrade);
                defaultSpeedDowngrade = defaultSpeedUpgrade;
                defaultSpeedUpgrade = (int)Math.Ceiling(defaultSpeedUpgrade * upgradeCostFactor);
                defaultSpeedUpgradeTxt.text = defaultSpeedUpgrade.ToString() + "g";
                defaultSpeedDowngradeTxt.text = defaultSpeedDowngrade.ToString() + "g";
                break;
            case "DDMS":
                levelPlayer.gainMoney(defaultSpeedDowngrade);
                defaultSpeedUpgrade = defaultSpeedDowngrade;

                if (min)
                {
                    defaultSpeedDowngrade = 0;

                }
                else
                {
                    defaultSpeedDowngrade = (int)Math.Floor(defaultSpeedDowngrade / upgradeCostFactor);
                }

                defaultSpeedUpgradeTxt.text = defaultSpeedUpgrade.ToString() + "g";
                defaultSpeedDowngradeTxt.text = defaultSpeedDowngrade.ToString() + "g";
                break;
            case "IDMH":
                levelPlayer.spendMoney(defaultHealthUpgrade);
                defaultHealthDowngrade = defaultHealthUpgrade;
                defaultHealthUpgrade = (int)Math.Ceiling(defaultHealthUpgrade * upgradeCostFactor);
                defaultHealthUpgradeTxt.text = defaultHealthUpgrade.ToString() + "g";
                defaultHealthDowngradeTxt.text = defaultHealthDowngrade.ToString() + "g";
                break;
            case "DDMH":
                levelPlayer.gainMoney(defaultHealthDowngrade);
                defaultHealthUpgrade = defaultHealthDowngrade;

                if (min)
                {
                    defaultHealthDowngrade = 0;
                }
                else
                {
                    defaultHealthDowngrade = (int)Math.Floor(defaultHealthDowngrade / upgradeCostFactor);
                }

                defaultHealthUpgradeTxt.text = defaultHealthUpgrade.ToString() + "g";
                defaultHealthDowngradeTxt.text = defaultHealthDowngrade.ToString() + "g";
                break;
            case "ISMS":
                levelPlayer.spendMoney(speedSpeedUpgrade);
                speedSpeedDowngrade = speedSpeedUpgrade;
                speedSpeedUpgrade = (int)Math.Ceiling(speedSpeedUpgrade * upgradeCostFactor);
                speedSpeedUpgradeTxt.text = speedSpeedUpgrade.ToString() + "g";
                speedSpeedDowngradeTxt.text = speedSpeedDowngrade.ToString() + "g";
                break;
            case "DSMS":
                levelPlayer.gainMoney(speedSpeedDowngrade);
                speedSpeedUpgrade = speedSpeedDowngrade;
                
                if (min)
                {
                    speedSpeedDowngrade = 0;
                }
                else
                {
                    speedSpeedDowngrade = (int)Math.Floor(speedSpeedDowngrade / upgradeCostFactor);
                }

                speedSpeedUpgradeTxt.text = speedSpeedUpgrade.ToString() + "g";
                speedSpeedDowngradeTxt.text = speedSpeedDowngrade.ToString() + "g";
                break;
            case "ISMH":
                levelPlayer.spendMoney(speedHealthUpgrade);
                speedHealthDowngrade = speedHealthUpgrade;
                speedHealthUpgrade = (int)Math.Ceiling(speedHealthUpgrade * upgradeCostFactor);
                speedHealthUpgradeTxt.text = speedHealthUpgrade.ToString() + "g";
                speedHealthDowngradeTxt.text = speedHealthDowngrade.ToString() + "g";
                break;
            case "DSMH":
                levelPlayer.gainMoney(speedHealthDowngrade);
                speedHealthUpgrade = speedHealthDowngrade;

                if (min)
                {
                    speedHealthDowngrade = 0;
                }
                else
                {
                    speedHealthDowngrade = (int)Math.Floor(speedHealthUpgrade / upgradeCostFactor);
                }

                speedHealthUpgradeTxt.text = speedHealthUpgrade.ToString() + "g";
                speedHealthDowngradeTxt.text = speedHealthDowngrade.ToString() + "g";
                break;
            case "ITMS":
                levelPlayer.spendMoney(tankSpeedUpgrade);
                tankSpeedDowngrade = tankSpeedUpgrade;
                tankSpeedUpgrade = (int)Math.Ceiling(tankSpeedUpgrade * upgradeCostFactor);
                tankSpeedUpgradeTxt.text = tankSpeedUpgrade.ToString() + "g";
                tankSpeedDowngradeTxt.text = tankSpeedDowngrade.ToString() + "g";
                break;
            case "DTMS":
                levelPlayer.gainMoney(tankSpeedDowngrade);
                tankSpeedUpgrade = tankSpeedDowngrade;

                if (min)
                {
                    tankSpeedDowngrade = 0;
                }
                else
                {
                    tankSpeedDowngrade = (int)Math.Floor(tankSpeedDowngrade / upgradeCostFactor);
                }

                tankSpeedUpgradeTxt.text = tankSpeedUpgrade.ToString() + "g";
                tankSpeedDowngradeTxt.text = tankSpeedDowngrade.ToString() + "g";
                break;
            case "ITMH":
                levelPlayer.spendMoney(tankHealthUpgrade);
                tankHealthDowngrade = tankHealthUpgrade;
                tankHealthUpgrade = (int)Math.Ceiling(tankHealthUpgrade * upgradeCostFactor);
                tankHealthUpgradeTxt.text = tankHealthUpgrade.ToString() + "g";
                tankHealthDowngradeTxt.text = tankHealthDowngrade.ToString() + "g";
                break;
            case "DTMH":
                levelPlayer.gainMoney(tankHealthDowngrade);
                tankHealthUpgrade = tankHealthDowngrade;

                if (min)
                {
                    tankHealthDowngrade = 0;
                }
                else
                {
                    tankHealthDowngrade = (int)Math.Floor(tankHealthDowngrade / upgradeCostFactor);
                }

                tankHealthUpgradeTxt.text = tankHealthUpgrade.ToString() + "g";
                tankHealthDowngradeTxt.text = tankHealthDowngrade.ToString() + "g";
                break;
        }
    }
}

