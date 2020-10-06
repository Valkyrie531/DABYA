﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public GameObject successPanel;
    public GameObject failPanel;
    public GameObject mainMenuButton;
    public GameObject quitGameButton;
    public GameObject LevelSelectButton;

    //set the success panel to active
    public void LevelSuccess()
    {
        successPanel.SetActive(true);
    }

    //set the fail panel to active
    public void LevelFail()
    {
        //failPanel.SetActive(true);
        SceneManager.LoadScene("GameOver");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
