using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LanguageUtils))]
public class LanguageMgr : MonoBehaviour
{
    private static LanguageMgr instance = null;

    /// <summary>
    /// 单例
    /// </summary>
    public static LanguageMgr Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("LanguageMgr is null...");
            }
            return instance;
        }
    }

    private SystemLanguage language = SystemLanguage.ChineseSimplified;

    // 加载的语言文件，即chinese.txt
    private TextAsset _textAsset;
    

    /// <summary>
    /// 相同的key 对应 不同国家的value
    /// </summary>
    private Dictionary<string, string> dict = new Dictionary<string, string>();

    /// <summary>
    /// 加载预翻译的语言,要适配6种语言，包括简体中文与繁体中文。
    /// </summary>
    private void LoadLanguage()
    {
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
            language = LanguageUtils.Instance.GetSystemLanguage();
        }

        if (language == SystemLanguage.ChineseSimplified ||
            language == SystemLanguage.English ||
            language == SystemLanguage.Vietnamese || 
            language == SystemLanguage.ChineseTraditional || 
            language == SystemLanguage.Korean ||
            language == SystemLanguage.Japanese)
        {
            _textAsset = Resources.Load<TextAsset>("Language/" + language.ToString());
        }
        else
        {
            _textAsset = Resources.Load<TextAsset>("Language/English");
        }

        //获取每一行
        string[] lines = _textAsset.text.Split('\n');
        //获取key value
        for (int i = 0; i < lines.Length; i++)
        {
            //检测
            if (string.IsNullOrEmpty(lines[i]))
                continue;
            //获取 key:kv[0] value kv[1]
            string[] kv = lines[i].Split(':');
            //保存到字典
            dict.Add(kv[0], kv[1]);

            // Debug.Log(string.Format("key:{0}, value:{1}", kv[0], kv[1]));
        }
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

        LoadLanguage();
    }

    /// <summary>
    /// 获取对应的value
    /// </summary>
    /// <param name="key">键</param>
    /// <returns>返回对应的value 如果不存在这个key 就返回空串</returns>
    public string GetText(string key)
    {
        if (dict.ContainsKey(key))
            return dict[key];
        else
        {
            //没有这个key
            return string.Empty;
        }
    }
}