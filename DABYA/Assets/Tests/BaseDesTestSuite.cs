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

}
