using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinShop : MonoBehaviour
{
    public GameObject defaultMonPanel;
    public GameObject speedMonPanel;
    public GameObject tankMonPanel;
    public Player user;
    private int skinPrice = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenDefaultSkinPanel()
    {
        CloseSpeedSkinPanel();
        CloseTankSkinPanel();
        defaultMonPanel.SetActive(true);
    }

    public void CloseDefaultSkinPanel()
    {
        defaultMonPanel.SetActive(false);
    }

    public void OpenSpeedSkinPanel()
    {
        CloseTankSkinPanel();
        CloseDefaultSkinPanel();
        speedMonPanel.SetActive(true);
    }

    public void CloseSpeedSkinPanel()
    {
        speedMonPanel.SetActive(false);
    }

    public void OpenTankSkinPanel()
    {
        CloseDefaultSkinPanel();
        CloseSpeedSkinPanel();
        tankMonPanel.SetActive(true);
    }

    public void CloseTankSkinPanel()
    {
        tankMonPanel.SetActive(false);
    }
}
