using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public LevelManager levelManager;
    public Text countdownText;
    public UpgradeMenu summonMenu;
    public SpawnMonster spawnMonster;

    private int totalWaves = 2;
    private int wavesLeft;
    private bool activeWave = false;

    private float countdownLength = 30;
    private float countdownFloat;

    public bool upgradeMenuActive = true;

    /*
     * Initiates amount of waves in current level.
     */
    void Start()
    {

        if (!SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            openUpgradeMenu();
        }
        wavesLeft = totalWaves;
        countdownFloat = countdownLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            countdownFloat -= Time.deltaTime;
        }
        countdownText.text = string.Format("{0:00.00}", countdownFloat);

        /*
         * Checks to see if there are waves needing to be sent (wavesLeft > 0)
         * and checks if there is an active wave on the board.
         * 
         * If waves are still needed and there is not an active wave then gives
         * money to the player and spawns a wave.
         */
        if(wavesLeft > 0 && !activeWave && !upgradeMenuActive)
        {
            Debug.Log("Wave" + wavesLeft);
            levelManager.playerMoneyAdjustor(100);
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
            wavesLeft -= 1;
            if (wavesLeft > 0)
            {
                spawnMonster.ClearMonsters();
                openUpgradeMenu();
            }
            countdownFloat = countdownLength;
            waveToggle();
        }
    }

    void openUpgradeMenu()
    {
        upgradeMenuActive = true;
        summonMenu.OpenUpgrades();
    }

    public void closeUpgradeMenu()
    {
        upgradeMenuActive = false;
        summonMenu.Play();
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


}
