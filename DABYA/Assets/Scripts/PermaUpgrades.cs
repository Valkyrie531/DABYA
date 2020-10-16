using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PermaUpgrades : MonoBehaviour
{
    private static float timerUpgrade = 0;
    private float timeUpgradeCounter = 0;
    private static int baseHealthDowngrade = 0;
    private float baseHealthCounter = 0;
    public Text baseHealthCounterTxt;
    public Text timeUpgradeCounterTxt;

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpgradeTime()
    {
        if(timeUpgradeCounter<10)
        {
            timeUpgradeCounter++;
            timerUpgrade += 5f;
            timeUpgradeCounterTxt.text = (timeUpgradeCounterTxt) + "/10";
        }
    }

    public float GetUpgradeTime()
    {
        return timerUpgrade;
    }

    public void LowerBaseHealth()
    {
        if(baseHealthCounter<10)
        {
            baseHealthCounter++;
            baseHealthDowngrade++;
            baseHealthCounterTxt.text = (baseHealthCounter) + "/10";
        }
    }

    public int GetBaseHealthDowngrade()
    {
        return baseHealthDowngrade;
    }
}
