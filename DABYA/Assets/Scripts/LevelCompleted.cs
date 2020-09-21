using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    public GameObject successPanel;
    public GameObject failPanel;

    //set the success panel to active
    public void LevelSuccess()
    {
        successPanel.SetActive(true);
    }

    //set the fail panel to active
    public void LevelFail()
    {

    }
}
