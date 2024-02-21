using System;
using System.Collections;
using System.Collections.Generic;
//using MadLevelManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidKeyInput : MonoBehaviour {

    private static AndroidKeyInput _instance = null;
    /// <summary>
    /// 单例
    /// </summary>
    public static AndroidKeyInput Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "AndroidKeyInput";
                go.AddComponent<AndroidKeyInput>();
                Debug.LogError("AndroidKeyInput Instance  is null，already created..");
            }
            return _instance;
        }
    }

    private string backToSceneName;
    private bool isExit;
    private bool isCalb;

    private Action CalbFunc;

    void Awake()
    {
        _instance = this;
    }

    public void CatchBackInput(string level_name,bool isQuit = false)
    {
        backToSceneName = level_name;
        isExit = isQuit;
    }

    public void CatchBackInputCallFunc(Action callFunc)
    {
        CalbFunc +=callFunc;
        isCalb = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isExit)
            {
                Application.Quit();
                return;
            }
            else
            {
                if (isCalb)
                {
                    CalbFunc();
                }
                else
                {
                    SceneManager.LoadScene(backToSceneName);
                }
            }
        }
    }
}
