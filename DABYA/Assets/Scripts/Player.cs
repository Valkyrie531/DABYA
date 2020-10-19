using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;
    public static int Credits = 0;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        //Need statement to get credits from database but obvs need the database implemented first
    }

    /*
     * Returns player money value as an int.
     */
    public int getMoney()
    {
        return Money;
    }

    /*
     * Changes player money value, only accepts int.
     */
    public void gainMoney(int moneyToAdd)
    {
        Money += moneyToAdd;
    }

    public void spendMoney(int moneyToSpend)
    {
        Money -= moneyToSpend;
    }

    public void ChangeCredits(int creditChangeInt)
    {
        Credits += creditChangeInt;
        Debug.Log("Player current credits: " + Credits);
    }
}