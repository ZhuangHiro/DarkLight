using System;
using System.Collections;
using System.Collections.Generic;
using MadLevelManager;
using UnityEngine;

public class SelectUI : MonoBehaviour
{

    private static SelectUI _instance = null;

    public static SelectUI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SelectUI is null");
            }
            return _instance;
        }
    }
    private MadSprite back_button;

    void Awake()
    {
        _instance = this;

        back_button = transform.GetComponent<MadSprite>("Panel/Anchor/back_button");
        MadlevelOption.GetInstance().OnSpriteClick(back_button, OnBackClick);

    }

    private void OnBackClick()
    {
        MadLevel.LoadPrevious();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
