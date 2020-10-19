using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelection : MonoBehaviour
{
    public static float startGoldModifier = 1.0f;
    public static float spendGoldModifier = 1.0f;
    public static float towerStatModifier = 1.0f;
    public static float baseHealthModifier = 1.0f;

    public void SetEasyDifficulty()
    {
        startGoldModifier = 1.5f;
        spendGoldModifier = 0.75f;
        towerStatModifier = 0.5f;
        baseHealthModifier = 0.75f;
    }

    public void SetNormalDifficulty()
    {
        startGoldModifier = 1.0f;
        spendGoldModifier = 1.0f;
        towerStatModifier = 1.0f;
        baseHealthModifier = 1.0f;
    }

    public void SetHardDifficulty()
    {
        startGoldModifier = 0.5f;
        spendGoldModifier = 1.25f;
        towerStatModifier = 1.5f;
        baseHealthModifier = 1.25f;
    }
}
