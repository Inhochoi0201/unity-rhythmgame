using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour
{
    [SerializeField] Text txtCoin = null;
    [SerializeField] GameObject goMainUI = null;
    [SerializeField] GameObject goWarning = null;
    [SerializeField] GameObject goArm = null;
    [SerializeField] GameObject showResult = null;
    [SerializeField] GameObject[] slot = null;
    [SerializeField] Animator warnningAnimator = null;
    [SerializeField] Animator armAnimator = null;
    [SerializeField] Animator resultAnimator = null;
    [SerializeField] Image skinResult = null;
    [SerializeField] Text changeSkin = null;


    string warn = "Warn";
    int r;

    PlayerController thePlayer;
    DatabaseManager theDatabase;
  
    
    void OnEnable()
    {
        AudioManager.instance.StopBGM();
        AudioManager.instance.PlayBGM("Store");
        if (theDatabase == null)
        {
            theDatabase = FindObjectOfType<DatabaseManager>();
            thePlayer = FindObjectOfType<PlayerController>();
        }

        txtCoin.text = string.Format("{0:#,##0}", theDatabase.coin);
        SetInvent();
    }

    public void SetInvent()
    {
        for (int i = 0; i < theDatabase.invent.Length; i++)
        {
            if (theDatabase.invent[i] == true) 
                slot[i].SetActive(true);
        }
    }

    public void BtnSkin0()
    {
        if (theDatabase.invent[0])
        {
            thePlayer.SetMat(0);
            changeSkin.text = "스킨(빨강)이 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
        }
    }
    public void BtnSkin1()
    {
        if (theDatabase.invent[1])
        {
            thePlayer.SetMat(1);
            changeSkin.text = "스킨(노랑)이 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
        }
    }
    public void BtnSkin2()
    {
        if (theDatabase.invent[2])
        {
            thePlayer.SetMat(2);
            changeSkin.text = "스킨(초록)이 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
        }
    }
    public void BtnSkin3()
    {
        if (theDatabase.invent[3])
        {
            thePlayer.SetMat(3);
            changeSkin.text = "스킨(파랑)이 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
        }
    }
    public void BtnSkin4()
    {
        if (theDatabase.invent[4])
        {
            thePlayer.SetMat(4);
            changeSkin.text = "스킨(그레이)이 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
        }
    }
    public void BtnSkin5()
    {
        if (theDatabase.invent[5])
        {
            thePlayer.SetMat(5);
            changeSkin.text = "스킨(검정)이 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
        }
    }

    public void BtnSkin6()
    {
            thePlayer.SetMat(6);
            changeSkin.text = "기본스킨으로 변경되었습니다.";
            AudioManager.instance.PlaySFX("Change");
            goArm.SetActive(true);
            armEffect();
    }

    public void BtnMain()
    {
        goMainUI.SetActive(true);
        this.gameObject.SetActive(false);
        AudioManager.instance.StopBGM();
    }

    public void WarnnigEffect()
    {
        warnningAnimator.SetTrigger(warn);
    }
    public void armEffect()
    {
        armAnimator.SetTrigger("Arm");
    }

    public void resultEffect()
    {
        resultAnimator.SetTrigger("Show");
    }
    public void BtnBuy()
    {
        if (theDatabase.coin >= 1) {
            AudioManager.instance.PlaySFX("Buy");
             r = Random.Range(0, 6);
            theDatabase.coin -= 1;
            theDatabase.SaveCoin();
            txtCoin.text = string.Format("{0:#,##0}", theDatabase.coin);
            theDatabase.invent[r] = true;
            theDatabase.SaveInvent();
            SetInvent();
            showResult.SetActive(true);
            ShowResult();
        }
        else
        {
            AudioManager.instance.PlaySFX("Err");
            goWarning.SetActive(true);
            WarnnigEffect();
        }
    }
    public void ShowResult()
    {
        resultEffect();
        switch(r){
            case 0: 
                skinResult.color = Color.red; 
                break;
            case 1:
                skinResult.color = Color.yellow;
                break;
            case 2:
                skinResult.color = Color.green;
                break;
            case 3:
                skinResult.color = Color.blue;
                break;
            case 4:
                skinResult.color = Color.gray;
                break;
            case 5:
                skinResult.color = new Color(0.3f, 0.3f, 0.3f);
                break;
            default : break;

        }
    }

    public void BtnX()
    {
        goWarning.SetActive(false);
        goArm.SetActive(false);
        showResult.SetActive(false);
    }
}
