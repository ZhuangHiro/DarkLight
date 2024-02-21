using System;
using DG.Tweening;
using MadLevelManager;
//using MadLevelManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StartUI : MonoBehaviour
{
    private static StartUI _instance = null;

    public static StartUI Instance
    {
        get
        {
            if (_instance == null) Debug.Log("StartUI is null");
            return _instance;
        }
    }

    // 引导按钮 
    private Transform guide_button;
    // 开始按钮 
    private Transform start_button;
    // 更多游戏按钮 
    private Transform games_button;


    void Awake()
    {
        _instance = this;

        guide_button = transform.GetComponent<Transform>("info_button");
        start_button = transform.GetComponent<Transform>("start_button");
        games_button = transform.GetComponent<Transform>("games_button");
    }

    void Start()
    {
        EventListener.Get(guide_button).SetEventListener(E_TouchType.OnClick,OnGuideClick,null);
        EventListener.Get(start_button).SetEventListener(E_TouchType.OnClick, OnStartClick, null);
        EventListener.Get(games_button).SetEventListener(E_TouchType.OnClick, OnGamesClick, null);
    }

    private void OnGiftClick(GameObject target, object eventData, object[] _params)
    {
        Debug.Log("OnGiftClick....");
    }

    private void OnDailiBonusClick(GameObject target, object eventData, object[] _params)
    {
        Debug.Log("OnDailiBonusClick....");
    }

    private void OnGamesClick(GameObject target, object eventData, object[] _params)
    {
        Debug.Log("OnGamesClick....");
    }

    private void OnShopClick(GameObject target, object eventData, object[] _params)
    {
        Debug.Log("OnShopClick....");
    }

    private void OnStartClick(GameObject target, object eventData, object[] _params)
    {
        MadLevel.LoadNext();
        Debug.Log("OnStartClick....");
    }

    private void OnGuideClick(GameObject target, object eventData, object[] _params)
    {
        Debug.Log("OnGuideClick....");
    }


}