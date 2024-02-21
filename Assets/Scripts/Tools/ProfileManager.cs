using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 加载页挂载当前脚本
/// </summary>
public class ProfileManager : MonoBehaviour
{

    private static ProfileManager _instance = null;

    public static ProfileManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "ProfileManager";
                go.AddComponent<ProfileManager>();
                Debug.LogError("ProfileManager is null,it already created!");
            }
            return _instance;
        }
    }

    private bool is_new_app;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        //ClearAllKeys();

        InitInfo();
    }

    private void InitInfo()
    {
        if (!PlayerPrefs.HasKey(StringUtils.IS_NEW_APP))
        {
            Debug.Log("游戏-首次-启动");
            is_new_app = true;
            Global.Instance().FirstInit();
        }
        else
        {
            Debug.Log("游戏-再次-启动");
            is_new_app = false;
            Global.Instance().Init();
        }

        if (!PlayerPrefs.HasKey(StringUtils.IS_NEW_APP))
        {
            PlayerPrefs.SetString(StringUtils.IS_NEW_APP, "IS_NEW_APP");
        }
    }

    public void SaveProfile()
    {
        // 存储用户Id

    }
    /// <summary>
    /// 用户首次启动返回true，二次启动返回false
    /// </summary>
    /// <returns></returns>
    public bool IS_NEW_APP()
    {
        return is_new_app;
    }

    public void ClearAllKeys()
    {
        PlayerPrefs.DeleteAll();
    }
    /// <summary>
    /// 返回存储的字符串
    /// </summary>
    /// <param name="str">索引名称</param>
    /// <returns></returns>
    public string GetString(string str)
    {
        string temp = "test";

        if (PlayerPrefs.HasKey(str))
        {
            temp = PlayerPrefs.GetString(str);
        }

        return temp;
    }
    /// <summary>
    /// 返回存储的整数
    /// </summary>
    /// <param name="str">索引名称</param>
    /// <returns></returns>
    public int GetInt(string str)
    {
        //return 1;
        int temp = -1;

        if (PlayerPrefs.HasKey(str))
        {
            temp = PlayerPrefs.GetInt(str);
        }
        return temp;
    }
    /// <summary>
    /// 返回存储的浮点数
    /// </summary>
    /// <param name="str">索引名称</param>
    /// <returns></returns>
    public float GetFloat(string str)
    {
        float temp = -1.0f;

        if (PlayerPrefs.HasKey(str))
        {
            temp = PlayerPrefs.GetFloat(str);
        }
        return temp;
    }

    void OnApplicationQuit()
    {
        SaveProfile();
    }

}
