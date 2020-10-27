using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class CurrencySpendingTestSuite
{
    private Player player;
    private UpgradeMenu upgradeMenu;
    private int expectedGold;
    private int actualGold;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("spend");
    }

    [UnityTest]
    public IEnumerator BasicMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.GetMoney() - upgradeMenu.defaultHealthUpgrade;
        upgradeMenu.IncreaseDefaultMonHealth();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseDefaultMonHealth();
        expectedGold = player.GetMoney() + upgradeMenu.defaultHealthDowngrade;
        upgradeMenu.DecreaseDefaultMonHealth();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterSpeedUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.GetMoney() - upgradeMenu.defaultSpeedUpgrade;
        upgradeMenu.IncreaseDefaultMonSpeed();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseDefaultMonSpeed();
        expectedGold = player.GetMoney() + upgradeMenu.defaultSpeedDowngrade;
        upgradeMenu.DecreaseDefaultMonSpeed();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.GetMoney() - upgradeMenu.speedHealthUpgrade;
        upgradeMenu.IncreaseSpeedMonHealth();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseSpeedMonHealth();
        expectedGold = player.GetMoney() + upgradeMenu.speedHealthDowngrade;
        upgradeMenu.DecreaseSpeedMonHealth();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterSpeedUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.GetMoney() - upgradeMenu.speedSpeedUpgrade;
        upgradeMenu.IncreaseSpeedMonSpeed();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseSpeedMonSpeed();
        expectedGold = player.GetMoney() + upgradeMenu.speedSpeedDowngrade;
        upgradeMenu.DecreaseSpeedMonSpeed();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.GetMoney() - upgradeMenu.tankHealthUpgrade;
        upgradeMenu.IncreaseTankMonHealth();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseTankMonHealth();
        expectedGold = player.GetMoney() + upgradeMenu.tankHealthDowngrade;
        upgradeMenu.DecreaseTankMonHealth();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterSpeedUpgrade()
{
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.GetMoney() - upgradeMenu.tankSpeedUpgrade;
        upgradeMenu.IncreaseTankMonSpeed();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseTankMonSpeed();
        expectedGold = player.GetMoney() + upgradeMenu.tankSpeedDowngrade;
        upgradeMenu.DecreaseTankMonSpeed();
        actualGold = player.GetMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }
}
