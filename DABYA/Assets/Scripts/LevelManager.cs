using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Base levelBase;
    public Player levelPlayer;
    public WaveSpawner levelSpawner;
    public GameObject levelCanvas;
    public Text baseHealth;
    public Text playerGold;
    public GameObject basicMonster;
    public GameObject speedMonster;
    public GameObject tankMonster;
    int counter = 0;

    private int totalWaves = 5;
    private int wavesLeft;

    /*
     * completed the level
     * based on if the base has been destroyed or not, show the level
     * success or level fail screen
     */
    public void LevelCompleted()
    {
        levelCanvas.SetActive(true);

        if (levelBase.IsDestroyed())
        {
            levelCanvas.GetComponent<LevelCompleted>().LevelSuccess();
        }
        else
        {
            levelCanvas.GetComponent<LevelCompleted>().LevelFail();
        }
    }

    /*
     * damage the base depending on the monster damage, passed through
     * by the monster to the base
     */
    public void BaseHitFor(int damage)
    {
        levelBase.BaseDamaged(damage);
    }

    public void playerMoneyAdjustor(int adjustment)
    {
        levelPlayer.changeMoney(adjustment);
    }

    //when started
    void Start()
    {
        wavesLeft = totalWaves;
        /*do (WaveSpawner things)
            {

        }
            while wavesLeft > 0;*/
        StartCoroutine(TestSpawn());
    }

    //updates the text for the base health
    void Update()
    {
        counter += 1;
        if ((counter % 200) == 0)
        {
            playerMoneyAdjustor(5);
        }
        baseHealth.text = levelBase.GetHealth().ToString() + " Health";
        playerGold.text = levelPlayer.getMoney().ToString() + " Gold available.";
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public IEnumerator TestSpawn()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject spawned;

            if (i % 3 == 0)
            {
                spawned = InstantiateBasic();
            }
            else if (i % 3 == 1)
            {
                spawned = InstantiateSpeed();
            }
            else
            {
                spawned = InstantiateTank();
            }

            spawned.GetComponent<Monster>().SetLevelManager(gameObject);

            yield return new WaitForSeconds(0.5f);
        }
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateBasic()
    {
        return Instantiate(basicMonster, levelSpawner.transform.position, levelSpawner.transform.rotation);
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateSpeed()
    {
        return Instantiate(speedMonster, levelSpawner.transform.position, levelSpawner.transform.rotation);
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateTank()
    {
        return Instantiate(tankMonster, levelSpawner.transform.position, levelSpawner.transform.rotation);
    }
}
