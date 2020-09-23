using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public LevelManager levelManager;
    public Text countdownText;
    public GameObject basicMonster;
    public GameObject speedMonster;
    public GameObject tankMonster;
    public GameObject spawnPoint;

    private int totalWaves = 2;
    private int wavesLeft;
    private bool activeWave = false;

    private float countdownFloat = 20;

    /*
     * Initiates amount of waves in current level.
     */
    void Start()
    {
        wavesLeft = totalWaves;
        basicMonster.GetComponent<Monster>().Reset();
        speedMonster.GetComponent<SpeedMonster>().Reset();
        tankMonster.GetComponent<TankMonster>().Reset();
    }

    // Update is called once per frame
    void Update()
    {
        countdownFloat -= Time.deltaTime;
        countdownText.text = string.Format("{0:00.00}", countdownFloat);

        /*
         * Checks to see if there are waves needing to be sent (wavesLeft > 0)
         * and checks if there is an active wave on the board.
         * 
         * If waves are still needed and there is not an active wave then gives
         * money to the player and spawns a wave.
         */
        if(wavesLeft > 0 && !activeWave)
        {
            Debug.Log("Wave" + wavesLeft);
            levelManager.playerMoneyAdjustor(100);
            StartCoroutine(TestSpawn());
            waveToggle();
        }

        /*
         * If waves reaches 0 then player has failed the level and level fail screen appears.
         */
        if(wavesLeft == 0)
        {
            levelManager.LevelCompleted();
        }

        /*
         * Functionality for timer at top of screen to show time left in the wave.
         */
        if(countdownFloat <= 0f)
        {
            Debug.Log("Wave over - upgrade screen shows up here");
            countdownFloat = 20;
            wavesLeft -= 1;
            waveToggle();
        }
    }

    /*
     * Boolean toggle to determine if there is currently a wave on the board.
     */
    void waveToggle()
    {
        if (activeWave)
            activeWave = false;
        else
            activeWave = true;
    }

    /*
     * damage the base depending on the monster damage, passed through
     * by the monster to the base
     */
    public void BaseHitFor(int damage)
    {
        levelManager.levelBase.BaseDamaged(damage);
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

            spawned.GetComponent<Monster>().SetLevelManager(levelManager);

            yield return new WaitForSeconds(0.5f);
        }
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateBasic()
    {
        return Instantiate(basicMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateSpeed()
    {
        return Instantiate(speedMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateTank()
    {
        return Instantiate(tankMonster, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
