using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMonster : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject basicMonster;
    public GameObject speedMonster;
    public GameObject tankMonster;
    public GameObject spawnPoint;
    public GoldNotice goldError;
    public Text normalSpawnCostText;
    public Text tankSpawnCostText;
    public Text speedSpawnCostText;
    public GameObject normalButton;
    public GameObject speedButton;
    public GameObject tankButton;

    private List<GameObject> monstersSpawned = new List<GameObject>();
    private float cooldownTime = 1f;

    /* Resets all attribute upgrades when level is started.
     * 
     */
    private void Start()
    {
        //basicMonster.GetComponent<Monster>().Reset();
       // speedMonster.GetComponent<SpeedMonster>().Reset();
       // tankMonster.GetComponent<TankMonster>().Reset();

        UpdateMonsterPrices();
    }

    private void UpdateMonsterPrices()
    {
        normalSpawnCostText.text = (basicMonster.GetComponent<Monster>().GetSpawnValue().ToString() + "g");
        tankSpawnCostText.text = (tankMonster.GetComponent<TankMonster>().GetSpawnValue().ToString() + "g");
        speedSpawnCostText.text = (speedMonster.GetComponent<SpeedMonster>().GetSpawnValue().ToString() + "g");
    }

    /* Instantiating (spawning) of basic monster after checking
     * that player can afford it.
     * 
     */
    public void InstantiateBasic()
    {
        if (CheckMoney(basicMonster.GetComponent<Monster>().GetSpawnValue()))
        {
            AudioManager.instance.Play("NormalSpawn");
            GameObject spawned;
            spawned = Instantiate(basicMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<Monster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
            normalButton.GetComponent<Animator>().SetTrigger("Active");
            DisableNormalButton();
        }
    }

    /* Instantiating (spawning) of speed monster after checking
     * that player can afford it.
     * 
     */
    public void InstantiateSpeed()
    {
        if (CheckMoney(speedMonster.GetComponent<SpeedMonster>().GetSpawnValue()))
        {
            AudioManager.instance.Play("SpeedSpawn");
            GameObject spawned;
            spawned = Instantiate(speedMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<SpeedMonster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
            speedButton.GetComponent<Animator>().SetTrigger("Active");
            DisableSpeedButton();
        }
    }

    /* Instantiating (spawning) of tank monster after checking
     * that player can afford it.
     * 
     */
    public void InstantiateTank()
    {
        if (CheckMoney(tankMonster.GetComponent<TankMonster>().GetSpawnValue()))
        {
            AudioManager.instance.Play("TankSpawn");
            GameObject spawned;
            spawned = Instantiate(tankMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
            spawned.GetComponent<TankMonster>().SetLevelManager(levelManager);
            monstersSpawned.Add(spawned);
            tankButton.GetComponent<Animator>().SetTrigger("Active");
            DisableTankButton();
        }
    }

    /* Paramater: int cost - the value you are attempting to check.
     * 
     * Function will check if player currently has more gold than
     * the value passed into the function.
     */
    private bool CheckMoney(int cost)
    {
        if (cost > levelManager.levelPlayer.GetMoney())
        {
            goldError.NotEnoughGoldPopUp();
            return false;
        }
        else
        {
            levelManager.PlayerMoneyAdjustor(-cost);
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
    public void DisableNormalButton()
    {
        normalButton.GetComponent<Button>().interactable = false;
        StartCoroutine(SpawnCooldown(normalButton.GetComponent<Button>()));
    }

    public void DisableSpeedButton()
    {
        speedButton.GetComponent<Button>().interactable = false;
        StartCoroutine(SpawnCooldown(speedButton.GetComponent<Button>()));
    }

    public void DisableTankButton()
    {
        tankButton.GetComponent<Button>().interactable = false;
        StartCoroutine(SpawnCooldown(tankButton.GetComponent<Button>()));
    }

    public IEnumerator SpawnCooldown(Button spawnButton)
    {
        yield return new WaitForSeconds(cooldownTime);
        spawnButton.interactable = true;
    }
}
