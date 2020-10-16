using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    
    public void openLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void openMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
