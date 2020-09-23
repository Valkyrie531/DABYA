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

        expectedGold = player.getMoney() - upgradeMenu.defaultHealthUpgrade;
        upgradeMenu.IncreaseDefaultMonHealth();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseDefaultMonHealth();
        expectedGold = player.getMoney() + upgradeMenu.defaultHealthDowngrade;
        upgradeMenu.DecreaseDefaultMonHealth();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterSpeedUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.getMoney() - upgradeMenu.defaultSpeedUpgrade;
        upgradeMenu.IncreaseDefaultMonSpeed();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator BasicMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseDefaultMonSpeed();
        expectedGold = player.getMoney() + upgradeMenu.defaultSpeedDowngrade;
        upgradeMenu.DecreaseDefaultMonSpeed();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.getMoney() - upgradeMenu.speedHealthUpgrade;
        upgradeMenu.IncreaseSpeedMonHealth();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseSpeedMonHealth();
        expectedGold = player.getMoney() + upgradeMenu.speedHealthDowngrade;
        upgradeMenu.DecreaseSpeedMonHealth();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterSpeedUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.getMoney() - upgradeMenu.speedSpeedUpgrade;
        upgradeMenu.IncreaseSpeedMonSpeed();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpeedMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseSpeedMonSpeed();
        expectedGold = player.getMoney() + upgradeMenu.speedSpeedDowngrade;
        upgradeMenu.DecreaseSpeedMonSpeed();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterHealthUpgrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.getMoney() - upgradeMenu.tankHealthUpgrade;
        upgradeMenu.IncreaseTankMonHealth();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterHealthDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseTankMonHealth();
        expectedGold = player.getMoney() + upgradeMenu.tankHealthDowngrade;
        upgradeMenu.DecreaseTankMonHealth();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterSpeedUpgrade()
{
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        expectedGold = player.getMoney() - upgradeMenu.tankSpeedUpgrade;
        upgradeMenu.IncreaseTankMonSpeed();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TankMonsterSpeedDowngrade()
    {
        player = Transform.FindObjectOfType<Player>();
        upgradeMenu = Transform.FindObjectOfType<UpgradeMenu>();

        upgradeMenu.IncreaseTankMonSpeed();
        expectedGold = player.getMoney() + upgradeMenu.tankSpeedDowngrade;
        upgradeMenu.DecreaseTankMonSpeed();
        actualGold = player.getMoney();

        Assert.AreEqual(expectedGold, actualGold, 0.1f);
        yield return null;
    }
}
