using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PermaUpgrades : MonoBehaviour
{
    public Player user;
    public Monster defaultMon;
    public SpeedMonster speedMon;
    public TankMonster tankMon;

    private static float timerUpgrade = 0;
    private float timeUpgradeCounter = 0;
    private int largeCost = 100;
    private int smallCost = 50;
    private static int baseHealthDowngrade = 0;
    private float baseHealthCounter = 0;
    public Text baseHealthCounterTxt;
    public Text timeUpgradeCounterTxt;
    public Text creditTxt;

    private void Start()
    {
        if(SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("PermaUpgradeScreen")))
        {
            ChangeCreditTxt();
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpgradeTime()
    {
        if(timeUpgradeCounter<10)
        {
            if (checkCredits(largeCost))
            {
                timeUpgradeCounter++;
                timerUpgrade += 5f;
                timeUpgradeCounterTxt.text = (timeUpgradeCounter) + "/10";
                user.ChangeCredits(-largeCost);
            }
        }
        ChangeCreditTxt();
    }

    public float GetUpgradeTime()
    {
        return timerUpgrade;
    }

    public void LowerBaseHealth()
    {
        if(baseHealthCounter<10)
        {
            if(checkCredits(largeCost))
            {
                baseHealthCounter++;
                baseHealthDowngrade++;
                baseHealthCounterTxt.text = (baseHealthCounter) + "/10";
                user.ChangeCredits(-largeCost);
            }
        }
        ChangeCreditTxt();
    }

    public int GetBaseHealthDowngrade()
    {
        return baseHealthDowngrade;
    }

    public bool checkCredits(int cost)
    {
        bool isTrue = false;
        if(user.GetCredits() >= cost)
        {
            isTrue = true;
        }
        return isTrue;
    }

    public void UpgradeDefaultMosterSpeed()
    {
        if(checkCredits(smallCost))
        {
            defaultMon.PremaUpgradeSpeed();
            user.ChangeCredits(-smallCost);
        }
        ChangeCreditTxt();
    }

    public void UpgradeDefaultMosterHealth()
    {
        if (checkCredits(smallCost))
        {
            defaultMon.PremaUpgradeHealth();
            user.ChangeCredits(-smallCost);
        }
        ChangeCreditTxt();
    }

    public void UpgradeDefaultMosterDamage()
    {
        if (checkCredits(smallCost))
        {
            defaultMon.PremaUpgradeDamage();
            user.ChangeCredits(-smallCost);
        }
        ChangeCreditTxt();
    }

    public void ChangeCreditTxt()
    {
        creditTxt.text = "Credits: " + user.GetCredits();
    }
}
