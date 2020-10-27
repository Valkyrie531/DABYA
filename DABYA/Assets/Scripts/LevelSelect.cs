using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //changes the scene from the level selection screen to the main menu screen
    public void returnToMainMeun()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void levelSelector()
    {
        AudioManager.instance.PlayGameMusic();
        switch (EventSystem.current.firstSelectedGameObject.name)
        {
            case "LevelOne":
                SceneManager.LoadScene("LevelOne");
                break;
            case "LevelTwo":
                SceneManager.LoadScene("LevelTwo");
                break;
            case "LevelThree":
                SceneManager.LoadScene("LevelThree");
                break;
            case "LevelFour":
                SceneManager.LoadScene("LevelFour");
                break;
            case "LevelFive":
                SceneManager.LoadScene("LevelFive");
                break;
            case "LevelSix":
                SceneManager.LoadScene("LevelSix");
                break;
            case "LevelSeven":
                SceneManager.LoadScene("LevelSeven");
                break;
        }
    }
}
