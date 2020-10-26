using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    public GameObject defaultMonPanel;
    public GameObject speedMonPanel;
    public GameObject tankMonPanel;
    public Player user;
    public Text creditTxt;
    public GameObject defaultMon;
    public GameObject speedMon;
    public GameObject tankMon;
    public Sprite defaultSkin1;
    public Sprite defaultSkin2;
    public Sprite defaultSkin3;
    public Sprite speedSkin1;
    public Sprite speedSkin2;
    public Sprite speedSkin3;
    public Sprite tankSkin1;
    public Sprite tankSkin2;
    public Sprite tankSkin3;
    private static bool dSkin1Unlocked = true;
    private static bool dSkin2Unlocked = false;
    private static bool dSkin3Unlocked = false;
    private static bool sSkin1Unlocked = true;
    private static bool sSkin2Unlocked = false;
    private static bool sSkin3Unlocked = false;
    private static bool tSkin1Unlocked = true;
    private static bool tSkin2Unlocked = false;
    private static bool tSkin3Unlocked = false;
    private static bool dSkin1Equipped = true;
    private static bool dSkin2Equipped = false;
    private static bool dSkin3Equipped = false;
    private static bool sSkin1Equipped = true;
    private static bool sSkin2Equipped = false;
    private static bool sSkin3Equipped = false;
    private static bool tSkin1Equipped = true;
    private static bool tSkin2Equipped = false;
    private static bool tSkin3Equipped = false;
    public GameObject purchaseDSkin2Btn;
    public GameObject purchaseDSkin3Btn;
    public GameObject purchaseSSkin2Btn;
    public GameObject purchaseSSkin3Btn;
    public GameObject purchaseTSkin2Btn;
    public GameObject purchaseTSkin3Btn;
    public Text equipDSkin1Txt;
    public Text equipDSkin2Txt;
    public Text equipDSkin3Txt;
    public Text equipSSkin1Txt;
    public Text equipSSkin2Txt;
    public Text equipSSkin3Txt;
    public Text equipTSkin1Txt;
    public Text equipTSkin2Txt;
    public Text equipTSkin3Txt;
    private int skinPrice = 100;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCreditTxt();

        if(dSkin2Unlocked)
        {
            RemovePurchaseButton(purchaseDSkin2Btn);
        }
        if (dSkin3Unlocked)
        {
            RemovePurchaseButton(purchaseDSkin3Btn);
        }
        if (sSkin2Unlocked)
        {
            RemovePurchaseButton(purchaseSSkin2Btn);
        }
        if (sSkin3Unlocked)
        {
            RemovePurchaseButton(purchaseSSkin3Btn);
        }
        if (tSkin2Unlocked)
        {
            RemovePurchaseButton(purchaseTSkin2Btn);
        }
        if (tSkin3Unlocked)
        {
            RemovePurchaseButton(purchaseTSkin3Btn);
        }

        if (dSkin1Equipped)
        {
            equipDSkin1Txt.text = "Equipped";
            equipDSkin2Txt.text = "Equip";
            equipDSkin3Txt.text = "Equip";
        }
        else if(dSkin2Equipped)
        {
            equipDSkin1Txt.text = "Equip";
            equipDSkin2Txt.text = "Equipped";
            equipDSkin3Txt.text = "Equip";
        }
        else if(dSkin3Equipped)
        {
            equipDSkin1Txt.text = "Equip";
            equipDSkin2Txt.text = "Equip";
            equipDSkin3Txt.text = "Equipped";
        }

        if (sSkin1Equipped)
        {
            equipSSkin1Txt.text = "Equipped";
            equipSSkin2Txt.text = "Equip";
            equipSSkin3Txt.text = "Equip";
        }
        else if (sSkin2Equipped)
        {
            equipSSkin1Txt.text = "Equip";
            equipSSkin2Txt.text = "Equipped";
            equipSSkin3Txt.text = "Equip";
        }
        else if (sSkin3Equipped)
        {
            equipSSkin1Txt.text = "Equip";
            equipSSkin2Txt.text = "Equip";
            equipSSkin3Txt.text = "Equipped";
        }

        if (tSkin1Equipped)
        {
            equipTSkin1Txt.text = "Equipped";
            equipTSkin2Txt.text = "Equip";
            equipTSkin3Txt.text = "Equip";
        }
        else if (tSkin2Equipped)
        {
            equipTSkin1Txt.text = "Equip";
            equipTSkin2Txt.text = "Equipped";
            equipTSkin3Txt.text = "Equip";
        }
        else if (tSkin3Equipped)
        {
            equipTSkin1Txt.text = "Equip";
            equipTSkin2Txt.text = "Equip";
            equipTSkin3Txt.text = "Equipped";
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    public void RemovePurchaseButton(GameObject toRemove)
    {
        toRemove.SetActive(false);
    }

    public bool CheckCredits(int cost)
    {
        if(user.GetCredits()>=cost)
        {
            return true;
        }
        return false;
    }

    public void ChangeCredits(int cost)
    {
        user.ChangeCredits(-cost);
    }

    public void UnlockDSkinTwo()
    {
        if(!dSkin2Unlocked)
        {
            if (CheckCredits(skinPrice))
            {
                dSkin2Unlocked = true;
                ChangeCredits(skinPrice);
                ChangeCreditTxt();
                RemovePurchaseButton(purchaseDSkin2Btn);
            }
        }
    }

    public void UnlockDSkinThree()
    {
        if (!dSkin3Unlocked)
        {
            if (CheckCredits(skinPrice))
            {
                dSkin3Unlocked = true;
                ChangeCredits(skinPrice);
                ChangeCreditTxt();
                RemovePurchaseButton(purchaseDSkin3Btn);
            }
        }
    }

    public void UnlockSSkinTwo()
    {
        if (!sSkin2Unlocked)
        {
            if (CheckCredits(skinPrice))
            {
                sSkin2Unlocked = true;
                ChangeCredits(skinPrice);
                ChangeCreditTxt();
                RemovePurchaseButton(purchaseSSkin2Btn);
            }
        }
    }

    public void UnlockSSkinThree()
    {
        if (!sSkin3Unlocked)
        {
            if (CheckCredits(skinPrice))
            {
                sSkin3Unlocked = true;
                ChangeCredits(skinPrice);
                ChangeCreditTxt();
                RemovePurchaseButton(purchaseSSkin3Btn);
            }
        }
    }

    public void UnlockTSkinTwo()
    {
        if (!tSkin2Unlocked)
        {
            if (CheckCredits(skinPrice))
            {
                tSkin2Unlocked = true;
                ChangeCredits(skinPrice);
                ChangeCreditTxt();
                RemovePurchaseButton(purchaseTSkin2Btn);
            }
        }
    }

    public void UnlockTSkinThree()
    {
        if (!tSkin3Unlocked)
        {
            if (CheckCredits(skinPrice))
            {
                tSkin3Unlocked = true;
                ChangeCredits(skinPrice);
                ChangeCreditTxt();
                RemovePurchaseButton(purchaseTSkin3Btn);
            }
        }
    }

    public void ChangeDefaultSkinOne()
    {
        if(dSkin1Unlocked)
        {
            defaultMon.GetComponent<SpriteRenderer>().sprite = defaultSkin1;
            dSkin1Equipped = true;
            dSkin2Equipped = false;
            dSkin3Equipped = false;
            equipDSkin1Txt.text = "Equipped";
            equipDSkin2Txt.text = "Equip";
            equipDSkin3Txt.text = "Equip";
        }
        
    }

    public void ChangeDefaultSkinTwo()
    {
        if (dSkin2Unlocked)
        {
            defaultMon.GetComponent<SpriteRenderer>().sprite = defaultSkin2;
            dSkin1Equipped = false;
            dSkin2Equipped = true;
            dSkin3Equipped = false;
            equipDSkin1Txt.text = "Equip";
            equipDSkin2Txt.text = "Equipped";
            equipDSkin3Txt.text = "Equip";
        }
    }

    public void ChangeDefaultSkinThree()
    {
        if(dSkin3Unlocked)
        {
            defaultMon.GetComponent<SpriteRenderer>().sprite = defaultSkin3;
            dSkin1Equipped = false;
            dSkin2Equipped = false;
            dSkin3Equipped = true;
            equipDSkin1Txt.text = "Equip";
            equipDSkin2Txt.text = "Equip";
            equipDSkin3Txt.text = "Equipped";
        }
    }

    public void ChangeSpeedSkinOne()
    {
        if (sSkin1Unlocked)
        {
            speedMon.GetComponent<SpriteRenderer>().sprite = speedSkin1;
            sSkin1Equipped = true;
            sSkin2Equipped = false;
            sSkin3Equipped = false;
            equipSSkin1Txt.text = "Equipped";
            equipSSkin2Txt.text = "Equip";
            equipSSkin3Txt.text = "Equip";
        }
    }

    public void ChangeSpeedSkinTwo()
    {
        if(sSkin2Unlocked)
        { 
            speedMon.GetComponent<SpriteRenderer>().sprite = speedSkin2;
            sSkin1Equipped = false;
            sSkin2Equipped = true;
            sSkin3Equipped = false;
            equipSSkin1Txt.text = "Equip";
            equipSSkin2Txt.text = "Equipped";
            equipSSkin3Txt.text = "Equip";
        }
    }

    public void ChangeSpeedSkinThree()
    {
        if(sSkin3Unlocked)
        { 
            speedMon.GetComponent<SpriteRenderer>().sprite = speedSkin3;
            sSkin1Equipped = false;
            sSkin2Equipped = false;
            sSkin3Equipped = true;
            equipSSkin1Txt.text = "Equip";
            equipSSkin2Txt.text = "Equip";
            equipSSkin3Txt.text = "Equipped";
        }
    }

    public void ChangeTankSkinOne()
    {
        if (tSkin1Unlocked)
        {
            tankMon.GetComponent<SpriteRenderer>().sprite = tankSkin1;
            tSkin1Equipped = true;
            tSkin2Equipped = false;
            tSkin3Equipped = false;
            equipTSkin1Txt.text = "Equipped";
            equipTSkin2Txt.text = "Equip";
            equipTSkin3Txt.text = "Equip";
        }
    }

    public void ChangeTankSkinTwo()
    {
        if(tSkin2Unlocked)
        { 
            tankMon.GetComponent<SpriteRenderer>().sprite = tankSkin2;
            tSkin1Equipped = false;
            tSkin2Equipped = true;
            tSkin3Equipped = false;
            equipTSkin1Txt.text = "Equip";
            equipTSkin2Txt.text = "Equipped";
            equipTSkin3Txt.text = "Equip";
        }
    }

    public void ChangeTankSkinThree()
    {
        if(tSkin3Unlocked)
        { 
            tankMon.GetComponent<SpriteRenderer>().sprite = tankSkin3;
            tSkin1Equipped = false;
            tSkin2Equipped = false;
            tSkin3Equipped = true;
            equipTSkin1Txt.text = "Equip";
            equipTSkin2Txt.text = "Equip";
            equipTSkin3Txt.text = "Equipped";
        }
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

    public void ChangeCreditTxt()
    {
        creditTxt.text = "Credits: " + user.GetCredits();
    }
}
