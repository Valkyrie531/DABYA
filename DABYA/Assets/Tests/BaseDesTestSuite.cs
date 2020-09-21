using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestSuite
{
    private Base levelBase;
    private Monster monster;
    private LevelManager level;
    private Canvas levelCompletion;
    private SummonMenu summonMenu;
    

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("LevelOne");
    }

    [UnityTest]
    public IEnumerator BaseTakesDamage()
    {
        int damage = 3;
        int expected = levelBase.GetHealth() - damage;

        levelBase = Transform.FindObjectOfType<Base>();

        levelBase.BaseDamaged(damage);

        Assert.AreEqual(expected, levelBase.GetHealth(), 0.1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator MonsterDamagesBase()
    {
        //spawn monster when monster spawn is completed

        levelBase = Transform.FindObjectOfType<Base>();
        monster = Transform.FindObjectOfType<Monster>();

        int expectedHealth = levelBase.GetHealth() - monster.baseDamage;
     
        monster.DamageBase();

        Assert.AreEqual(expectedHealth, levelBase.GetHealth(), 0.1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LevelCompletedPopsUp()
    {
        level = Transform.FindObjectOfType<LevelManager>();

        level.LevelCompleted();
        yield return new WaitForSeconds(0.2f);

        Assert.IsNotNull(levelCompletion = Transform.FindObjectOfType<Canvas>());
        Assert.IsTrue(levelCompletion.enabled);
    }
    
    [UnityTest]
    public IEnumerator BaseDestuctionTriggersPopUp()
    {
        levelBase = Transform.FindObjectOfType<Base>();
        level = Transform.FindObjectOfType<LevelManager>();

        levelBase.BaseDestroyed();

        yield return new WaitForSeconds(0.2f);

        Assert.IsNotNull(levelCompletion = Transform.FindObjectOfType<Canvas>());
        Assert.IsTrue(levelCompletion.enabled);
    }

    [UnityTest]
    public IEnumerator SummonMenuPopUp()
    {
        summonMenu = Transform.FindObjectOfType<SummonMenu>();
      
        Assert.IsTrue(summonMenu.summonMenuUI.activeSelf);
        yield return null;     
    }

    [UnityTest]
    public IEnumerator IncresedBy10()
    {
        summonMenu = Transform.FindObjectOfType<SummonMenu>();
        summonMenu.IncreaseDefaultMonHealth();
        Assert.AreEqual(summonMenu.defaultMonHealthTxt.text,"110");

        summonMenu.IncreaseSpeedMonHealth();
        Assert.AreEqual(summonMenu.speedMonHealthTxt.text, "60");

        summonMenu.IncreaseTankMonHealth();
        Assert.AreEqual(summonMenu.tankMonHealthTxt.text, "210");

        yield return null;
    }

    [UnityTest]
    public IEnumerator DecresedBy10()
    {
        summonMenu = Transform.FindObjectOfType<SummonMenu>();
        summonMenu.DecreaseDefaultMonHealth();
        Assert.AreEqual(summonMenu.defaultMonHealthTxt.text, "90");

        summonMenu.DecreaseSpeedMonHealth();
        Assert.AreEqual(summonMenu.speedMonHealthTxt.text, "40");

        summonMenu.DecreaseTankMonHealth();
        Assert.AreEqual(summonMenu.tankMonHealthTxt.text, "190");
        yield return null;
    }

    [UnityTest]
    public IEnumerator IncresedByDotOne()
    {
        summonMenu = Transform.FindObjectOfType<SummonMenu>();
        summonMenu.IncreaseDefaultMonSpeed();
        Assert.AreEqual(summonMenu.defaultMonSpeedTxt.text, "10.1");

        summonMenu.IncreaseSpeedMonSpeed();
        Assert.AreEqual(summonMenu.speedMonSpeedTxt.text, "15.1");

        summonMenu.IncreaseTankMonSpeed();
        Assert.AreEqual(summonMenu.tankMonSpeedTxt.text, "5.1");

        yield return null;
    }

    [UnityTest]
    public IEnumerator DecresedByDotOne()
    {
        summonMenu = Transform.FindObjectOfType<SummonMenu>();
        summonMenu.DecreaseDefaultMonSpeed();
        Assert.AreEqual(summonMenu.defaultMonSpeedTxt.text, "9.9");

        summonMenu.DecreaseSpeedMonSpeed();
        Assert.AreEqual(summonMenu.speedMonSpeedTxt.text, "14.9");

        summonMenu.DecreaseTankMonSpeed();
        Assert.AreEqual(summonMenu.tankMonSpeedTxt.text, "4.9");
        yield return null;
    }
}
