﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour
{
    public GameObject mainMenuButton;
    public GameObject replayLevelButton;
    public GameObject levelSelectButton;
    public Text levelCompletionText;
    public Text levelScoreText;

    //set the success panel to active
    public void LevelSuccess(int score)
    {
        levelCompletionText.text = "Good job, you won!";
        UpdateScoreText(score);
    }

    //set the fail panel to active
    public void LevelFail(int score)
    {
        levelCompletionText.text = "Oh no, you lost.";
        UpdateScoreText(score);
    }

    /* Updates score and sets the level completion text to advise
     * user of the score they achieved on that level.
     */
    public void UpdateScoreText(int score)
    {
        levelScoreText.text = "You scored " + score.ToString() + " points in that level!";
    }

    public void ReplayLevel()
    {
        AudioManager.instance.PlayGameMusic();
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
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
