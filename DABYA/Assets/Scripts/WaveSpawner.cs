using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public LevelManager levelManager;
    public Text countdownText;

    private int countdownInt = 60;

    // Start is called before the first frame update
    void Start()
    {
        countdownText.text = countdownInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
