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

    //takes the user back to the main menu
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /* Upgrades the time limit for each wave
     * 
     */
    public void UpgradeTime()
    {
        if(timeUpgradeCounter<10)
        {
            if (CheckCredits(largeCost))
            {
                timeUpgradeCounter++;
                timerUpgrade += 5f;
                timeUpgradeCounterTxt.text = (timeUpgradeCounter) + "/10";
                user.ChangeCredits(-largeCost);
            }
        }
        ChangeCreditTxt();
    }

    //returns the upgrade value
    public float GetUpgradeTime()
    {
        return timerUpgrade;
    }

    /*Decreases the health of the base
     * 
     */
    public void LowerBaseHealth()
    {
        if(baseHealthCounter<10)
        {
            if(CheckCredits(largeCost))
            {
                baseHealthCounter++;
                baseHealthDowngrade++;
                baseHealthCounterTxt.text = (baseHealthCounter) + "/10";
                user.ChangeCredits(-largeCost);
            }
        }
        ChangeCreditTxt();
    }
    //reutrns the amount of health to remove from the base
    public int GetBaseHealthDowngrade()
    {
        return baseHealthDowngrade;
    }

<<<<<<< Updated upstream
    //checks if the user can afford the upgrade
    public bool checkCredits(int cost)
=======
    public bool CheckCredits(int cost)
>>>>>>> Stashed changes
    {
        bool isTrue = false;
        if(user.GetCredits() >= cost)
        {
            isTrue = true;
        }
        return isTrue;
    }

    /*upgrades the speed of all monsters
     * 
     */
    public void UpgradeDefaultMosterSpeed()
    {
        if(CheckCredits(smallCost))
        {
            defaultMon.PremaUpgradeSpeed();
            user.ChangeCredits(-smallCost);
        }
        ChangeCreditTxt();
    }

    /*upgrades all monsters health
     * 
     */
    public void UpgradeDefaultMosterHealth()
    {
        if (CheckCredits(smallCost))
        {
            defaultMon.PremaUpgradeHealth();
            user.ChangeCredits(-smallCost);
        }
        ChangeCreditTxt();
    }

    /*Increases the damage of all monster
     * 
     */
    public void UpgradeDefaultMosterDamage()
    {
        if (CheckCredits(smallCost))
        {
            defaultMon.PremaUpgradeDamage();
            user.ChangeCredits(-smallCost);
        }
        ChangeCreditTxt();
    }

    //update the text saying how many credits the user has
    public void ChangeCreditTxt()
    {
        creditTxt.text = "Credits: " + user.GetCredits();
    }
}
