using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Changes the scene from the main menu to the level selection screen
    public void openLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //completely closes the game
    public void closeGame()
    {
        Application.Quit();
    }
}
