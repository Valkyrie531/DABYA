using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //changes the scene from the level selection screen to the main menu screen
    public void ReturnToMainMeun()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelector()
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
        }
    }
}
