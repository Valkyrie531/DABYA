using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void returnToMainMeun()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
