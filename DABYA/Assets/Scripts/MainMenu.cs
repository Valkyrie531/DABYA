using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Changes the scene from the main menu to the level selection screen
    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //opens the permanent upgrade menu
    public void OpenUpgrades()
    {
        SceneManager.LoadScene("PermaUpgradeScreen");
    }

    //completely closes the game
    public void CloseGame()
    {
        Application.Quit();
    }
}
