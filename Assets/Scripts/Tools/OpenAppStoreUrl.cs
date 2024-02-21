using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppStoreUrl : MonoBehaviour
{
    // App内部打开：itunes.apple.com/developer/id1449161724
    // 网页浏览：itunes.apple.com/cn/developer/id1449161724

    void Start()
    {
        EventListener.Get(transform).SetEventListener(E_TouchType.OnClick, OnUrlClick, null);
    }

    private void OnUrlClick(GameObject target, object eventData, object[] _params)
    {

        // 移动平台语言
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL("market://search?q=pub:夕艺游戏");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.OpenURL("http://itunes.apple.com/developer/id1449161724");

        }

    }
}
