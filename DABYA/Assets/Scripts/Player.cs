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

    public int getMoney()
    {
        return Money;
    }

    public void changeMoney(int goldToAdd)
    {
        Money += goldToAdd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
