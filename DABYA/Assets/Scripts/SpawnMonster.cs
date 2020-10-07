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

    private List<GameObject> monstersSpawned = new List<GameObject>();

    /* Resets all attribute upgrades when level is started.
     * 
     */
    private void Start()
    {
        basicMonster.GetComponent<Monster>().Reset();
        speedMonster.GetComponent<SpeedMonster>().Reset();
        tankMonster.GetComponent<TankMonster>().Reset();
    }

    /* Instantiating (spawning) of basic monster after checking
     * that player can afford it.
     * 
     */
    public void InstantiateBasic()
    {
        if (CheckMoney(basicMonster.GetComponent<Monster>().getSpawnValue()))
        {
            GameObject spawned;
            spawned = Instantiate(basicMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<Monster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
        }
    }

    /* Instantiating (spawning) of speed monster after checking
     * that player can afford it.
     * 
     */
    public void InstantiateSpeed()
    {
        if (CheckMoney(speedMonster.GetComponent<SpeedMonster>().getSpawnValue()))
        {
            GameObject spawned;
            spawned = Instantiate(speedMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<SpeedMonster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
        }
    }

    /* Instantiating (spawning) of tank monster after checking
     * that player can afford it.
     * 
     */
    public void InstantiateTank()
    {
        if (CheckMoney(tankMonster.GetComponent<TankMonster>().getSpawnValue()))
        {
            GameObject spawned;
            spawned = Instantiate(tankMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<TankMonster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
        }
    }

    /* Paramater: int cost - the value you are attempting to check.
     * 
     * Function will check if player currently has more gold than
     * the value passed into the function.
     */
    private bool CheckMoney(int cost)
    {
        if (cost > levelManager.levelPlayer.getMoney())
            return false;
        else
        {
            levelManager.playerMoneyAdjustor(-cost);
            return true;
        }
    }

    /* Function will clear the list of monsters effectively removing
     * all instances of any type of monster within the level.
     * 
     */
    public void ClearMonsters()
    {
        foreach(GameObject g in monstersSpawned)
        {
            Destroy(g);
        }

        monstersSpawned.Clear();
    }

    /* Getter function for monstersSpawned list.
     * 
     */
    public List<GameObject> GetMonstersSpawned()
    {
        return monstersSpawned;
    }
}
