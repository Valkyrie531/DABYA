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
        Money = startMoney;
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
    public void changeMoney(int moneyToAdd)
    {
        Money += moneyToAdd;
    }

    // Update is called once per frame
    void Update()
    {

    }
}