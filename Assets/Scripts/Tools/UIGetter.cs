using System;
using  UnityEngine;


public class UIGetter
{
    private static UIGetter instance = null;
    private UIGetter()
    {
    }

    public static UIGetter GetInstance()
    {
        if (instance == null)
        {
            instance = new UIGetter();
        }
        return instance;
    }
    /// <summary>
    /// 由于扩展类无法搜索到隐藏的物体，特此创建此工具类。
    /// </summary>
    /// <param name="transform">获取组件的父物体</param>
    /// <param name="path">组件的路径</param>
    /// <returns></returns>
    public Transform FindTransform(Transform transform,string path)
    {
        Transform t;
        t = transform.Find(path);
        return t;
    }
    /// <summary>
    /// 由于扩展类无法搜索到隐藏的物体，特此创建此工具类。
    /// </summary>
    /// <param name="transform">获取组件的父物体</param>
    /// <param name="path">组件的路径</param>
    /// <returns></returns>
    public GameObject FindGameObject(Transform transform, string path)
    {
        GameObject go;
        go = transform.Find(path).gameObject;
        return go;
    }

}
