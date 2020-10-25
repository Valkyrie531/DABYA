using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class PermaUpgradeTests
    {
        Monster testMonster;
        float expected;

        [SetUp]
        public void SetUp()
        {
            SceneManager.LoadScene("LevelOne");
            testMonster = Transform.FindObjectOfType<Monster>();
        }

        [UnityTest]
        public IEnumerator PermaUpgradeSpeedTest()
        {
            expected = testMonster.GetComponent<Monster>().GetUpgradedSpeed() + 0.1f;
            testMonster.PremaUpgradeSpeed();
            Assert.AreEqual(expected, testMonster.GetUpgradedSpeed(), 0.01f);
            yield return null;
        }

        [UnityTest]
        public IEnumerator PermaUpgradeHealthTest()
        {
            expected = testMonster.GetComponent<Monster>().GetUpgradedHealth() + 10;
            testMonster.PremaUpgradeHealth();
            Assert.AreEqual(expected, testMonster.GetUpgradedHealth(), 0.1f);
            yield return null;
        }

        [UnityTest]
        public IEnumerator PermaUpgradeDamageTest()
        {
            expected = testMonster.GetComponent<Monster>().GetUpgradedDamage() + 1;
            testMonster.PremaUpgradeDamage();
            Assert.AreEqual(expected, testMonster.GetUpgradedDamage(), 0.1f);
            yield return null;
        }
    }
}
