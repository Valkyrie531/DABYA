using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    //changes the scene from the level selection screen to the main menu screen
    public void returnToMainMeun()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
