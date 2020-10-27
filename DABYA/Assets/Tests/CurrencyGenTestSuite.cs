using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework.Interfaces;

public class CurrencyGenTestSuite
{
    private LevelManager levelManager;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("LevelOne");
    }

    [UnityTest]
    public IEnumerator PlayerHasCurrency()
    {
        int playerMoney = 0;

        levelManager = Transform.FindObjectOfType<LevelManager>();

        playerMoney = levelManager.levelPlayer.GetMoney();

        Assert.NotZero(playerMoney);
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCurrencyChanger()
    {
        int expected;

        levelManager = Transform.FindObjectOfType<LevelManager>();

        expected = levelManager.levelPlayer.GetMoney() + 100;

        levelManager.PlayerMoneyAdjustor(100);

        Assert.AreEqual(expected, levelManager.levelPlayer.GetMoney());
        yield return null;
    }

    [UnityTest]
    public IEnumerator RegularCurrencyGeneration()
    {
        int original;

        levelManager = Transform.FindObjectOfType<LevelManager>();

        original = levelManager.levelPlayer.GetMoney();

        levelManager.levelSpawner.CloseUpgradeMenu();

        yield return new WaitForSeconds(1f);

        Assert.AreNotEqual(original, levelManager.levelPlayer.GetMoney());
        yield return null;
    }

}
