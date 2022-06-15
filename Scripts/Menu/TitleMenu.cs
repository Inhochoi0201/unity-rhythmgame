using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] GameObject goStageUI = null;
    [SerializeField] GameObject goStoreUI = null;

   public void BtnPlay()
    {
        goStageUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void BtnStore()
    {
        goStoreUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
