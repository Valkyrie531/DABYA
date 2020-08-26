using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void openLevelSelect()
    {
        Debug.Log("Open level select");
    }


    public void openCredits()
    {
        Debug.Log("Open Credits");
        SceneManager.LoadScene("Credits");
    }

    public void closeGame()
    {
        Debug.Log("close game");
        Application.Quit();
    }
}
