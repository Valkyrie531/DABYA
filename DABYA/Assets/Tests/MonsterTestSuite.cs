using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework.Interfaces;

public class MonsterTestSuite
{
    private LevelManager levelManager;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("LevelOne");
    }

    [UnityTest]
    public IEnumerator MonsterSpawns()
    {
        levelManager = Transform.FindObjectOfType<LevelManager>();

        levelManager.levelSpawner.closeUpgradeMenu();

        yield return new WaitForSeconds(0.1f);

        levelManager.levelSpawner.spawnMonster.InstantiateBasic();

        Assert.NotZero(levelManager.levelSpawner.spawnMonster.monstersSpawned.Count);
        yield return null;
    }

    [UnityTest]
    public IEnumerator MonstersCleared()
    {
        levelManager = Transform.FindObjectOfType<LevelManager>();

        levelManager.levelSpawner.closeUpgradeMenu();

        yield return new WaitForSeconds(0.1f);

        levelManager.levelSpawner.spawnMonster.InstantiateBasic();

        levelManager.levelSpawner.spawnMonster.clearMonsters();

        Assert.Zero(levelManager.levelSpawner.spawnMonster.monstersSpawned.Count);
        yield return null;
    }

    [UnityTest]
    public IEnumerator MonstersMoveAutomatically()
    {
        levelManager = Transform.FindObjectOfType<LevelManager>();

        levelManager.levelSpawner.closeUpgradeMenu();

        yield return new WaitForSeconds(0.1f);

        levelManager.levelSpawner.spawnMonster.InstantiateBasic();

        float initialXPos = levelManager.levelSpawner.spawnMonster.monstersSpawned[0].transform.position.x;

        yield return new WaitForSeconds(0.1f);

        Assert.Greater(levelManager.levelSpawner.spawnMonster.monstersSpawned[0].transform.position.x, initialXPos);
        yield return null;
    }
}
