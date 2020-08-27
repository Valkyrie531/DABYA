using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void openLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    public void openCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
