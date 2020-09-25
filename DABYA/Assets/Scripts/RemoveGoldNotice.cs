using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGoldNotice : MonoBehaviour
{
    public void RemoveNotEnoughGoldText()
    {
        Destroy(gameObject);
    }
}
