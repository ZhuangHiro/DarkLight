using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopDrug : MonoBehaviour {

    public static ShopDrug _instance;
    private DOTweenAnimation tween;
    private bool isShow = false;
    private GameObject numberDialog;
    private InputField numberInput;
    private int buy_id;


    void Awake()
    {
        _instance = this;
        tween = this.GetComponent<DOTweenAnimation>();
        numberDialog = this.transform.Find("NumberDialog").gameObject;
        numberInput = this.transform.Find("NumberDialog/NumberInput").GetComponent<InputField>();
        numberDialog.gameObject.SetActive(false);
    }
    public void TransformState()
    {
        if (isShow == false)
        {
            tween.DOPlayForward();isShow = true;
        }
        else
        {
            tween.DOPlayBackwards();isShow = false;
        }
    }

    public void CloseButtonClick()
    {
        TransformState();
    }

    public void OnBuyId1001()
    {
        Buy(1001);
    }
    public void OnBuyId1002()
    {
        Buy(1002);
    }
    public void OnBuyId1003()
    {
        Buy(1003);
    }
    void Buy(int id)
    {
        ShowNumberDialog();
        buy_id = id;
    }
    public void OnOkButtonClick()
    {
        int count = int.Parse(numberInput.text);
        ObjectsInfo.ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(buy_id);
        int price_buy = info.price_buy;
        int price_total = price_buy * count;
        bool success = Inventory._instance.GetCoin(price_total);
        if (success&&count>0)
        {
            Inventory._instance.GetId(buy_id, count);
        }
        numberDialog.gameObject.SetActive(false);
    }
    void ShowNumberDialog()
    {
        numberDialog.gameObject.SetActive(true);
        numberInput.text = "0";
    }
}
