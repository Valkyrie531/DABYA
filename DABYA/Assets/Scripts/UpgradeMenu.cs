using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
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

        //the following similarly name functions change the text to be the same as the value of the stats
    public void IncreaseDefaultMonSpeed()
    {
        defaultMonSpeed += 0.1m;
        defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
    }

    public void DecreaseDefaultMonSpeed()
    {
        defaultMonSpeed -= 0.1m;
        defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
    }

    public void IncreaseDefaultMonHealth()
    {
        defaultMonHealth += 10;
        defaultMonHealthTxt.text = defaultMonHealth.ToString();
    }

    public void DecreaseDefaultMonHealth()
    {
        defaultMonHealth -= 10;
        defaultMonHealthTxt.text = defaultMonHealth.ToString();
    }

    public void IncreaseSpeedMonSpeed()
    {
        speedMonSpeed += 0.1m;
        speedMonSpeedTxt.text = speedMonSpeed.ToString();
    }

    public void DecreaseSpeedMonSpeed()
    {
        speedMonSpeed -= 0.1m;
        speedMonSpeedTxt.text = speedMonSpeed.ToString();
    }

    public void IncreaseSpeedMonHealth()
    {
        speedMonHealth += 10;
        speedMonHealthTxt.text = speedMonHealth.ToString();
    }

    public void DecreaseSpeedMonHealth()
    {
        speedMonHealth -= 10;
        speedMonHealthTxt.text = speedMonHealth.ToString();
    }

    public void IncreaseTankMonSpeed()
    {
        tankMonSpeed += 0.1m;
        tankMonSpeedTxt.text = tankMonSpeed.ToString();
    }

    public void DecreaseTankMonSpeed()
    {
        tankMonSpeed -= 0.1m;
        tankMonSpeedTxt.text = tankMonSpeed.ToString();
    }

    public void IncreaseTankMonHealth()
    {
        tankMonHealth += 10;
        tankMonHealthTxt.text = tankMonHealth.ToString();
    }

    public void DecreaseTankMonHealth()
    {
        tankMonHealth -= 10;
        tankMonHealthTxt.text = tankMonHealth.ToString();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        if(Monster.FindObjectOfType(typeof(Monster)) == null)
        {
            OpenUpgrades();
        }
        else
        {
            Play();
        }
    }*/
}

