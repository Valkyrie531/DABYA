using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNotice : MonoBehaviour
{
    public GameObject goldError;
 
    public void RemoveNotEnoughGoldText()
    {
        Destroy(gameObject);
    }

    public void NotEnoughGoldPopUp()
    {
        GameObject goldErrorPopup = Instantiate(goldError, goldError.transform.position, goldError.transform.rotation);
        goldErrorPopup.transform.SetParent(goldError.transform.parent);
        goldErrorPopup.SetActive(true);
        Destroy(goldErrorPopup, goldErrorPopup.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
