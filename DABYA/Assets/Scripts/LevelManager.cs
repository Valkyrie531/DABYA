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
            levelSpawner.spawnMonster.clearMonsters();
        }
    }

    /*
      * Adjusts money for player object in level
      */
    public void playerMoneyAdjustor(int adjustment)
    {
        if (!pausedMenu.getPaused())
        {
            levelPlayer.changeMoney(adjustment);
        }
    }

    //when started
    void Start()
    {

    }

    //updates the text for the base health and player money
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
}
