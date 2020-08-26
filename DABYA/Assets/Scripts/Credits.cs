using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void returnToMainMenu()
    {
        Debug.Log("return");
        SceneManager.LoadScene("MainMenu");
    }
}
