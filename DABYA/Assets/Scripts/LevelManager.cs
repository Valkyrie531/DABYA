using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Base levelBase;
    public GameObject levelCanvas;
    public Text baseHealth;

    public void LevelSuccess()
    {
        levelCanvas.SetActive(true);
    }

    public void BaseHitFor(int damage)
    {
        levelBase.BaseDamaged(damage);
    }

    void Update()
    {
        baseHealth.text = levelBase.health.ToString() + " Health";
    }
}
