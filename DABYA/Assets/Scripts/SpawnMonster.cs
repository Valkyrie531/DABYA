using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject basicMonster;
    public GameObject speedMonster;
    public GameObject tankMonster;
    public GameObject spawnPoint;
    public List<GameObject> monstersSpawned = new List<GameObject>();

    private void Start()
    {
        basicMonster.GetComponent<Monster>().Reset();
        speedMonster.GetComponent<SpeedMonster>().Reset();
        tankMonster.GetComponent<TankMonster>().Reset();
    }

    public void Test()
    {
        StartCoroutine(TestSpawn());
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public IEnumerator TestSpawn()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i % 3 == 0)
            {
                InstantiateBasic();
            }
            else if (i % 3 == 1)
            {
                InstantiateSpeed();
            }
            else
            {
                InstantiateTank();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public void InstantiateBasic()
    {
        if (checkMoney(basicMonster.GetComponent<Monster>().getSpawnValue()))
        {
            GameObject spawned;
            spawned = Instantiate(basicMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<Monster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
        }
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public void InstantiateSpeed()
    {
        if (checkMoney(speedMonster.GetComponent<SpeedMonster>().getSpawnValue()))
        {
            GameObject spawned;
            spawned = Instantiate(speedMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<SpeedMonster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
        }
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public void InstantiateTank()
    {
        if (checkMoney(tankMonster.GetComponent<TankMonster>().getSpawnValue()))
        {
            GameObject spawned;
            spawned = Instantiate(tankMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<TankMonster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
        }
    }

    public bool checkMoney(int cost)
    {
        if (cost > levelManager.levelPlayer.getMoney())
            return false;
        else
        {
            levelManager.playerMoneyAdjustor(-cost);
            return true;
        }
    }

    public void clearMonsters()
    {
        foreach(GameObject g in monstersSpawned)
        {
            Destroy(g);
        }

        monstersSpawned.Clear();
    }
}
