using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Player levelPlayer;
    public Text playerGold;

    public GameObject upgradeMenuUI;
    //public Text defaultMonNumTxt;
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
    public int defaultSpeedDowngrade;
    public Text defaultSpeedDowngradeTxt;
    [HideInInspector]
    public int speedSpeedUpgrade = 10;
    public Text speedSpeedUpgradeTxt;
    [HideInInspector]
    public int speedSpeedDowngrade;
    public Text speedSpeedDowngradeTxt;
    [HideInInspector]
    public int tankSpeedUpgrade = 30;
    public Text tankSpeedUpgradeTxt;
    [HideInInspector]
    public int tankSpeedDowngrade;
    public Text tankSpeedDowngradeTxt;

    //health upgrade values and text for all monsters
    [HideInInspector]
    public int defaultHealthUpgrade = 20;
    public Text defaultHealthUpgradeTxt;
    [HideInInspector]
    public int defaultHealthDowngrade;
    public Text defaultHealthDowngradeTxt;
    [HideInInspector]
    public int speedHealthUpgrade = 30;
    public Text speedHealthUpgradeTxt;
    [HideInInspector]
    public int speedHealthDowngrade;
    public Text speedHealthDowngradeTxt;
    [HideInInspector]
    public int tankHealthUpgrade = 10;
    public Text tankHealthUpgradeTxt;
    [HideInInspector]
    public int tankHealthDowngrade;
    public Text tankHealthDowngradeTxt;

    private float upgradeCostFactor = 1.5f;

    public bool OpenUpgrades ()
    {
        Debug.Log("TEST");
        upgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        return true;
    }

    public void Play()
    {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    /* public void AddDefaultMonster()
     {
         defaultMonNum++;
         defaultMonNumTxt.text = defaultMonNum.ToString();
     }

     public void RemoveDefaultMonster()
     {
         defaultMonNum--;
         defaultMonNumTxt.text = defaultMonNum.ToString();
     }*/


    // Update is called once per frame
    void Update()
    {
        /*if(Monster.FindObjectOfType(typeof(Monster)) == null)
        {
            OpenUpgrades();
        }
        else
        {
            Play();
        }*/

        playerGold.text = levelPlayer.getMoney().ToString() + " Gold available.";
    }

    //the following similarly name functions change the text to be the same as the value of the stats
    public void IncreaseDefaultMonSpeed()
    {
        if (CheckMoney(defaultSpeedUpgrade))
        {
            defaultMonSpeed += 0.1m;
            defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
            UpdateCost("IDMS");
        }
    }

    public void DecreaseDefaultMonSpeed()
    {
        defaultMonSpeed -= 0.1m;
        defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
        UpdateCost("DDMS");
    }

    public void IncreaseDefaultMonHealth()
    {
        if (CheckMoney(defaultHealthUpgrade))
        {
            defaultMonHealth += 10;
            defaultMonHealthTxt.text = defaultMonHealth.ToString();
            UpdateCost("IDMH");
        }
    }

    public void DecreaseDefaultMonHealth()
    {
        defaultMonHealth -= 10;
        defaultMonHealthTxt.text = defaultMonHealth.ToString();
        UpdateCost("DDMH");
    }

    public void IncreaseSpeedMonSpeed()
    {
        if (CheckMoney(speedSpeedUpgrade))
        {
            speedMonSpeed += 0.1m;
            speedMonSpeedTxt.text = speedMonSpeed.ToString();
            UpdateCost("ISMS");
        }
    }

    public void DecreaseSpeedMonSpeed()
    {
        speedMonSpeed -= 0.1m;
        speedMonSpeedTxt.text = speedMonSpeed.ToString();
        UpdateCost("DSMS");
    }

    public void IncreaseSpeedMonHealth()
    {
        if (CheckMoney(speedHealthUpgrade))
        {
            speedMonHealth += 10;
            speedMonHealthTxt.text = speedMonHealth.ToString();
            UpdateCost("ISMH");
        }
    }

    public void DecreaseSpeedMonHealth()
    {
        speedMonHealth -= 10;
        speedMonHealthTxt.text = speedMonHealth.ToString();
        UpdateCost("DSMH");
    }

    public void IncreaseTankMonSpeed()
    {
        if (CheckMoney(tankSpeedUpgrade))
        {
            tankMonSpeed += 0.1m;
            tankMonSpeedTxt.text = tankMonSpeed.ToString();
            UpdateCost("ITMS");
        }
    }

    public void DecreaseTankMonSpeed()
    {
        tankMonSpeed -= 0.1m;
        tankMonSpeedTxt.text = tankMonSpeed.ToString();
        UpdateCost("DTMS");
    }

    public void IncreaseTankMonHealth()
    {
        if (CheckMoney(tankHealthUpgrade))
        {
            tankMonHealth += 10;
            tankMonHealthTxt.text = tankMonHealth.ToString();
            UpdateCost("ITMH");
        }
    }

    public void DecreaseTankMonHealth()
    {
        tankMonHealth -= 10;
        tankMonHealthTxt.text = tankMonHealth.ToString();
        UpdateCost("DTMH");
    }

    public bool CheckMoney(int cost)
    {
        if (cost > levelPlayer.getMoney())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void UpdateCost(string code)
    {
        switch (code)
        {
            case "IDMS":
                levelPlayer.spendMoney(defaultSpeedUpgrade);
                defaultSpeedDowngrade = defaultSpeedUpgrade;
                defaultSpeedUpgrade = (int)Math.Ceiling(defaultSpeedUpgrade * upgradeCostFactor);
                defaultSpeedUpgradeTxt.text = defaultSpeedUpgrade.ToString();
                defaultSpeedDowngradeTxt.text = defaultSpeedDowngrade.ToString();
                break;
            case "DDMS":
                levelPlayer.gainMoney(defaultSpeedDowngrade);
                defaultSpeedUpgrade = defaultSpeedDowngrade;
                defaultSpeedDowngrade = (int)Math.Ceiling(defaultSpeedDowngrade / upgradeCostFactor);
                defaultSpeedUpgradeTxt.text = defaultSpeedUpgrade.ToString();
                defaultSpeedDowngradeTxt.text = defaultSpeedDowngrade.ToString();
                break;
            case "IDMH":
                levelPlayer.spendMoney(defaultHealthUpgrade);
                defaultHealthDowngrade = defaultHealthUpgrade;
                defaultHealthUpgrade = (int)Math.Ceiling(defaultHealthUpgrade * upgradeCostFactor);
                defaultHealthUpgradeTxt.text = defaultHealthUpgrade.ToString();
                defaultHealthDowngradeTxt.text = defaultHealthDowngrade.ToString();
                break;
            case "DDMH":
                levelPlayer.gainMoney(defaultHealthDowngrade);
                defaultHealthUpgrade = defaultHealthDowngrade;
                defaultHealthDowngrade = (int)Math.Ceiling(defaultHealthDowngrade / upgradeCostFactor);
                defaultHealthUpgradeTxt.text = defaultHealthUpgrade.ToString();
                defaultHealthDowngradeTxt.text = defaultHealthDowngrade.ToString();
                break;
            case "ISMS":
                levelPlayer.spendMoney(speedSpeedUpgrade);
                speedSpeedDowngrade = speedSpeedUpgrade;
                speedSpeedUpgrade = (int)Math.Ceiling(speedSpeedUpgrade * upgradeCostFactor);
                speedSpeedUpgradeTxt.text = speedSpeedUpgrade.ToString();
                speedSpeedDowngradeTxt.text = speedSpeedDowngrade.ToString();
                break;
            case "DSMS":
                levelPlayer.gainMoney(speedSpeedDowngrade);
                speedSpeedUpgrade = speedSpeedDowngrade;
                speedSpeedDowngrade = (int)Math.Ceiling(speedSpeedDowngrade / upgradeCostFactor);
                speedSpeedUpgradeTxt.text = speedSpeedUpgrade.ToString();
                speedSpeedDowngradeTxt.text = speedSpeedDowngrade.ToString();
                break;
            case "ISMH":
                levelPlayer.spendMoney(speedHealthUpgrade);
                speedHealthDowngrade = speedHealthUpgrade;
                speedHealthUpgrade = (int)Math.Ceiling(speedHealthUpgrade * upgradeCostFactor);
                speedHealthUpgradeTxt.text = speedHealthUpgrade.ToString();
                speedHealthDowngradeTxt.text = speedHealthDowngrade.ToString();
                break;
            case "DSMH":
                levelPlayer.gainMoney(speedHealthDowngrade);
                speedHealthDowngrade = speedHealthUpgrade;
                speedHealthUpgrade = (int)Math.Ceiling(speedHealthUpgrade / upgradeCostFactor);
                speedHealthUpgradeTxt.text = speedHealthUpgrade.ToString();
                speedHealthDowngradeTxt.text = speedHealthDowngrade.ToString();
                break;
            case "ITMS":
                levelPlayer.spendMoney(tankSpeedUpgrade);
                tankSpeedDowngrade = tankSpeedUpgrade;
                tankSpeedUpgrade = (int)Math.Ceiling(tankSpeedUpgrade * upgradeCostFactor);
                tankSpeedUpgradeTxt.text = tankSpeedUpgrade.ToString();
                tankSpeedDowngradeTxt.text = tankSpeedDowngrade.ToString();
                break;
            case "DTMS":
                levelPlayer.gainMoney(tankSpeedDowngrade);
                tankSpeedUpgrade = tankSpeedDowngrade;
                tankSpeedDowngrade = (int)Math.Ceiling(tankSpeedDowngrade / upgradeCostFactor);
                tankSpeedUpgradeTxt.text = tankSpeedUpgrade.ToString();
                tankSpeedDowngradeTxt.text = tankSpeedDowngrade.ToString();
                break;
            case "ITMH":
                levelPlayer.spendMoney(tankHealthUpgrade);
                tankHealthDowngrade = tankHealthUpgrade;
                tankHealthUpgrade = (int)Math.Ceiling(tankHealthUpgrade * upgradeCostFactor);
                tankHealthUpgradeTxt.text = tankHealthUpgrade.ToString();
                tankHealthDowngradeTxt.text = tankHealthDowngrade.ToString();
                break;
            case "DTMH":
                levelPlayer.gainMoney(tankHealthDowngrade);
                tankHealthUpgrade = tankHealthDowngrade;
                tankHealthDowngrade = (int)Math.Ceiling(tankHealthDowngrade / upgradeCostFactor);
                tankHealthUpgradeTxt.text = tankHealthUpgrade.ToString();
                tankHealthDowngradeTxt.text = tankHealthDowngrade.ToString();
                break;
        }
    }
}

