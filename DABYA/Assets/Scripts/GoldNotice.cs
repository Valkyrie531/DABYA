using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNotice : MonoBehaviour
{
    public GameObject goldErrorPosition;
    public GameObject goldError;
 
    public void RemoveNotEnoughGoldText()
    {
        Destroy(gameObject);
    }

    public void NotEnoughGoldPopUp()
    {
        GameObject goldErrorPopup = Instantiate(goldError, goldErrorPosition.transform.position, goldErrorPosition.transform.rotation);
        goldErrorPopup.transform.SetParent(goldErrorPosition.transform.parent);
        goldErrorPopup.SetActive(true);
        Destroy(goldErrorPopup, goldErrorPopup.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
