using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Base levelBase;
    public Player levelPlayer;
    public WaveSpawner levelSpawner;
    public GameObject levelCanvas;
    public PauseMenu pausedMenu;
    public Text baseHealth;
    public Text playerGold;

    int counter = 0;
    float gameSpeed = 1;
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
            levelSpawner.spawnMonster.ClearMonsters();
        }
    }

    public void FastFoward()
    {
        if (gameSpeed == 1)
        {
            gameSpeed = 4;
        }
        else if (pausedMenu.getPaused())
        {
            gameSpeed = 0;
        }
        else
        {
            gameSpeed = 1;
        }
        Time.timeScale = gameSpeed;
    }
    /*
      * Adjusts money for player object in level
      */
    public void playerMoneyAdjustor(int adjustment)
    {
        if (!pausedMenu.getPaused())
        {
			levelPlayer.gainMoney(adjustment);
        }
    }

    //when started
    void Start()
    {

    }

    //updates the text for the base health and player money
    void Update()
    {
        if (!levelSpawner.upgradeMenuActive)
        {
            counter += 1;
            if ((counter % 200) == 0)
            {
                playerMoneyAdjustor(5);
            }
        }

        if (pausedMenu.getPaused())
        {
            gameSpeed = 1;
        }
        baseHealth.text = levelBase.GetHealth().ToString() + " Health";
        playerGold.text = levelPlayer.getMoney().ToString() + " Gold available.";
    }
}
