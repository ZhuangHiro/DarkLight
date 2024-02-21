using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUtils : MonoBehaviour {

    private static LanguageUtils instance = null;
    /// <summary>
    /// 单例
    /// </summary>
    public static LanguageUtils Instance
    {
        get { return instance; }
    }


    [SerializeField]
    private SystemLanguage language;

    void Awake ()
    {
        instance = this;

        language = GetSystemLanguage();

    }

    public SystemLanguage GetSystemLanguage()
    {
        //Debug.Log("LanguageUtils is " + language.ToString());
        // 移动平台语言
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            language = Application.systemLanguage;

            Debug.Log("本地语言为->" + language);
        }
        // 编辑器语言
        else if (Application.platform == RuntimePlatform.WindowsEditor ||
                 Application.platform == RuntimePlatform.OSXEditor)
        {
            Debug.Log("编辑器本地语言本地语言为->" + language);
        }
        return language;
    }
}
