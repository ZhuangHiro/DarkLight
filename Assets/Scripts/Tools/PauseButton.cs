using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 当前类是封装的专门负责暂停按钮的Item类，主要负责静音与恢复的操作。其关闭的按钮图片必须命名为OFF。
/// </summary>
public class PauseButton : MonoBehaviour
{

    private Transform pause;
    private Transform resume;
    public GameObject PausePanel;
    void Awake()
    {
        pause = transform;
        resume = transform.Find("OFF");
        resume.gameObject.SetActive(false);
        InitListener();
    }

    private void InitListener()
    {
        EventListener.Get(pause).SetEventListener(E_TouchType.OnClick, OnPauseClick, null);
        EventListener.Get(resume).SetEventListener(E_TouchType.OnClick, OnResumeClick, null);
    }

    private int index = 0;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            if (index % 2 == 0)
            {
                Pause();
            }
            else
            {
                Resume();
            }
            index++;
        }
    }

    private void OnPauseClick(GameObject target, object eventData, object[] _params)
    {
        Pause();
    }

    private void OnResumeClick(GameObject target, object eventData, object[] _params)
    {
        Resume();
    }


    // 静音
    private void Pause()
    {
        resume.gameObject.SetActive(true);
        if(PausePanel !=null) PausePanel.SetActive(true);
    }
    // 恢复播放音乐
    private void Resume()
    {
        resume.gameObject.SetActive(false);
        if (PausePanel != null) PausePanel.SetActive(false);
    }

}
