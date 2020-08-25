using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void openLevelSelect()
    {
        Debug.Log("Open level select");
    }


    public void openCredits()
    {
        Debug.Log("Open credits");
    }

    public void closeGame()
    {
        Debug.Log("close game");
        Application.Quit();
    }
}
