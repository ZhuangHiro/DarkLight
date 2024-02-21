using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILanguageText : MonoBehaviour
{


    /// <summary>
    /// 对应的key
    /// </summary>
    [SerializeField]
    private string key;

    void Start()
    {
        //设置key之后 才需要改变
        if (!string.IsNullOrEmpty(key))
        {
            //获取对应的value
            string value = LanguageMgr.Instance.GetText(key);
            if (!string.IsNullOrEmpty(value))
            {
                //给text组件赋值
                GetComponent<Text>().text = value;
            }
            else
            {
                Debug.LogError("没有找到" + key + "的译文");
            }
        }
    }
    /// <summary>
    /// 更新当前文本内容
    /// </summary>
    /// <param name="key">待更新文本内容</param>
    public void UpdateText(string key)
    {
        //设置key之后 才需要改变
        if (!string.IsNullOrEmpty(key))
        {
            //获取对应的value
            string value = LanguageMgr.Instance.GetText(key);
            if (!string.IsNullOrEmpty(value))
            {
                //给text组件赋值
                GetComponent<Text>().text = value;
            }
            else
            {
                Debug.LogError("没有找到" + key + "的译文");
            }
        }
    }
}
