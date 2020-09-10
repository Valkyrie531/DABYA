using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

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

    [TearDown]
    public void TearDown()
    {
        if (levelBase != null)
        {
            Object.Destroy(levelBase.gameObject);
        }

        if (monster != null)
        {
            Object.Destroy(monster.gameObject);
        }

        if (level != null)
        {
            Object.Destroy(level.gameObject);
        }
    }

    [UnityTest]
    public IEnumerator BaseTakesDamage()
    {

        levelBase = Transform.FindObjectOfType<Base>();

        levelBase.Damaged(3);

        Assert.AreEqual(17, levelBase.health, 0.1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator MonsterDamagesBase()
    {
        var monsterPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Monster.prefab");

        GameObject.Instantiate(monsterPrefab, new Vector3(0, 0, -1), Waypoints.points[0].rotation);

        levelBase = Transform.FindObjectOfType<Base>();
        monster = Transform.FindObjectOfType<Monster>();

        int expectedHealth = levelBase.health - monster.baseDamage;
     
        monster.DamageBase();

        Assert.AreEqual(expectedHealth, levelBase.health, 0.1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LevelCompletedPopsUp()
    {
        level = Transform.FindObjectOfType<LevelManager>();

        level.LevelSuccess();
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
