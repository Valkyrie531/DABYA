using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class CurrencySpendingTestSuite
{/*
    private Player player;
    private SummonMenu upgradeMenu;
    private int expectedGold;
    private int actualGold;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("spendCurrency");
    }

    [UnityTest]
    public IEnumerator BasicMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        expectedGold = player.getMoney() - upgradeMenu.defaultHealthUpgrade;
        upgradeMenu.IncreaseDefaultMonHealth();
        actualGold = upgradeMenu.defaultHealthUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        upgradeMenu.IncreaseDefaultMonHealth();
        expectedGold = player.getMoney() - upgradeMenu.defaultHealthUpgrade;
        upgradeMenu.DecreaseDefaultMonHealth();
        actualGold = upgradeMenu.defaultHealthUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterSpeedUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        expectedGold = player.getMoney() - upgradeMenu.defaultSpeedUpgrade;
        upgradeMenu.IncreaseDefaultMonSpeed();
        actualGold = upgradeMenu.defaultSpeedUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        upgradeMenu.IncreaseDefaultMonSpeed();
        expectedGold = player.getMoney() - upgradeMenu.defaultHealthUpgrade;
        upgradeMenu.DecreaseDefaultMonSpeed();
        actualGold = upgradeMenu.defaultHealthUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        expectedGold = player.getMoney() - upgradeMenu.speedHealthUpgrade;
        upgradeMenu.IncreaseSpeedMonHealth();
        actualGold = upgradeMenu.speedHealthUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        upgradeMenu.IncreaseSpeedMonHealth();
        expectedGold = player.getMoney() - upgradeMenu.defaultHealthUpgrade;
        upgradeMenu.DecreaseSpeedMonHealth();
        actualGold = upgradeMenu.defaultHealthUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterSpeedUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        expectedGold = player.getMoney() - upgradeMenu.speedSpeedUpgrade;
        upgradeMenu.IncreaseSpeedMonSpeed();
        actualGold = upgradeMenu.speedSpeedUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        upgradeMenu.IncreaseSpeedMonSpeed();
        expectedGold = player.getMoney() - upgradeMenu.speedSpeedDowngrade;
        upgradeMenu.DecreaseSpeedMonSpeed();
        actualGold = upgradeMenu.speedSpeedDowngrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        expectedGold = player.getMoney() - upgradeMenu.tankHealthUpgrade;
        upgradeMenu.IncreaseTankMonHealth();
        actualGold = upgradeMenu.tankHealthUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        upgradeMenu.IncreaseTankMonHealth();
        expectedGold = player.getMoney() - upgradeMenu.tankHealthDowngrade;
        upgradeMenu.DecreaseTankMonHealth();
        actualGold = upgradeMenu.tankHealthDowngrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterSpeedUpgrade()
{
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();

        expectedGold = player.getMoney() - upgradeMenu.tankSpeedUpgrade;
        upgradeMenu.IncreaseTankMonSpeed();
        actualGold = upgradeMenu.tankSpeedUpgrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterSpeedDowngrade()
    {

        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<SummonMenu>();
        upgradeMenu.IncreaseTankMonSpeed();
        expectedGold = player.getMoney() - upgradeMenu.tankSpeedDowngrade;
        upgradeMenu.DecreaseTankMonSpeed();
        actualGold = upgradeMenu.tankSpeedDowngrade;

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }*/
}
