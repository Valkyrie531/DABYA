using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;

    // Start is called before the first frame update
    void Start()
    {
        Money = (int)Math.Floor(startMoney * DifficultySelection.startGoldModifier);
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

    // Update is called once per frame
    void Update()
    {

    }
}