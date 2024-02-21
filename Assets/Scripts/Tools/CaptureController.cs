using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour {


    private static CaptureController _instance = null;
    /// <summary>
    /// 单例
    /// </summary>
    public static CaptureController Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "CaptureController";

                Debug.LogError("CaptureController Instance  is null，already created..");
            }
            return _instance;
        }
    }

    void Awake ()
    {
        _instance = this;
    }

    /// <summary>
    /// 截图方法
    /// </summary>
    /// <param name="callback">截图完成的回调方法,其传入的texture即为截图的图片纹理</param>
    /// <returns></returns>
    public void Capture(Action<Texture2D> callback)
    {
        StartCoroutine(CaptureImage(callback));
    }


    /// <summary>
    /// 截图方法
    /// </summary>
    /// <param name="callback">截图完成的回调方法,其传入的texture即为截图的图片纹理</param>
    /// <returns></returns>
    private IEnumerator CaptureImage(Action<Texture2D> callback)
    {
        //图片大小  
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);

        //坐标左下角为0,屏幕宽高为截图尺寸。
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        // 协程阻塞
        yield return new WaitForEndOfFrame();
        // 读取截图像素
        texture.ReadPixels(rect, 0, 0, true);
        // 完成纹理生成
        texture.Apply();
        // 返回纹理
        yield return texture;
        // 截图完成的回调
        callback(texture);
    }
}
