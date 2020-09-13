using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonMenu : MonoBehaviour
{
    public GameObject summonMenuUI;
    public Text defaultMonNumTxt;
    public int defaultMonNum = 0;
    public Text defaultMonSpeedTxt;
    public int defaultMonSpeed = 10;
    public Text defaultMonHealthTxt;
    public int defaultMonHealth = 100;

    void Summon ()
    {
        summonMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void Play ()
    {
        summonMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddDefaultMonster()
    {
        defaultMonNum++;
        defaultMonNumTxt.text = defaultMonNum.ToString();
    }

    public void RemoveDefaultMonster()
    {
        defaultMonNum--;
        defaultMonNumTxt.text = defaultMonNum.ToString();
    }

    public void IncreaseDefaultMonSpeed()
    {
        defaultMonSpeed++;
        defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
    }

    public void DecreaseDefaultMonSpeed()
    {
        defaultMonSpeed--;
        defaultMonSpeedTxt.text = defaultMonSpeed.ToString();
    }

    public void IncreaseDefaultMonHealth()
    {
        defaultMonHealth+=10;
        defaultMonHealthTxt.text = defaultMonHealth.ToString();
    }

    public void DecreaseDefaultMonHealth()
    {
        defaultMonHealth-=10;
        defaultMonHealthTxt.text = defaultMonHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Monster.FindObjectOfType(typeof(Monster)) == null)
        {
            Summon();
        }
        else
        {
            Play();
        }
    }
}

