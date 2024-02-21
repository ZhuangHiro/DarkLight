using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 当前类是封装的专门负责音乐音效按钮的Item类，主要负责静音与恢复的操作。其关闭的按钮图片必须命名为OFF。
/// </summary>
public class MusicButton : MonoBehaviour
{

    public AudioClip audioClip;

    // 是否静音有背景音乐，反之为音效
    public bool isMusic;

    private Transform music_on;
    private Transform music_off;
    void Awake()
    {
        music_on = transform;
        music_off = transform.Find("OFF");
        music_off.gameObject.SetActive(false);
        InitListener();
    }

    void Start()
    {
        if (isMusic)
        {
            if (AudioUtils.IsBGMPause)
            {
                music_off.gameObject.SetActive(true);
            }

        }
        else
        {
            if (AudioUtils.IsSoundPause)
            {
                music_off.gameObject.SetActive(true);
            }
        }
    }

    private void InitListener()
    {
        EventListener.Get(music_on).SetEventListener(E_TouchType.OnClick, OnMusicONClick, null);
        EventListener.Get(music_off).SetEventListener(E_TouchType.OnClick, OnMusicOFFClick, null);
    }

    private void OnMusicONClick(GameObject target, object eventData, object[] _params)
    {
        AudioController.Instance.SoundPlay(audioClip.name);
        Mute();
        music_off.gameObject.SetActive(true);
    }

    private void OnMusicOFFClick(GameObject target, object eventData, object[] _params)
    {
        AudioController.Instance.SoundPlay(audioClip.name);
        UnMute();

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            music_off.gameObject.SetActive(false);
        }, 0.1f));
    }


    // 静音
    private void Mute()
    {
        if (isMusic)
        {
            AudioUtils.IsBGMPause = true;
            AudioController.Instance.BGMPause();
        }
        else
        {
            AudioUtils.IsSoundPause = true;
            AudioController.Instance.SoundAllPause();
        }
    }
    // 恢复播放音乐
    private void UnMute()
    {
        if (isMusic)
        {
            AudioUtils.IsBGMPause = false;
            AudioController.Instance.BGMReplay();
        }
        else
        {
            AudioUtils.IsSoundPause = false;
            AudioController.Instance.SoundResume();
        }

    }
}
