using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Base levelBase;
    public GameObject levelCanvas;
    public Text baseHealth;
    public GameObject basicMonster;
    public GameObject speedMonster;
    public GameObject tankMonster;

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

    //when started
    void Start()
    {
        basicMonster.GetComponent<Monster>().Reset();
        speedMonster.GetComponent<SpeedMonster>().Reset();
        tankMonster.GetComponent<TankMonster>().Reset();
        //StartCoroutine(TestSpawn());
    }

    public void starting()//waits until a it is called to run the co routine
    {
        StartCoroutine(TestSpawn());
    }

    //updates the text for the base health
    void Update()
    {
        baseHealth.text = levelBase.GetHealth().ToString() + " Health";
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
        return Instantiate(basicMonster, levelBase.transform.position, levelBase.transform.rotation);
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateSpeed()
    {
        return Instantiate(speedMonster, levelBase.transform.position, levelBase.transform.rotation);
    }

    //placeholder monster spawn - to be remonved when proper spawner is done
    public GameObject InstantiateTank()
    {
        return Instantiate(tankMonster, levelBase.transform.position, levelBase.transform.rotation);
    }
}
