using UnityEngine;
using System.Collections;

public static class MonoBehaviourExtend
{

    public static T GetOrAddCompoment<T>(this GameObject go, string path = "") where T : Component
    {
        Transform t;
        if (string.IsNullOrEmpty(path))
        {
            t = go.transform;
        }
        else
        {
            t = go.transform.Find(path);
        }
        if (t == null)
        {
            Debug.LogError("GetOrAddCompoment Not Find GameObject at Path" + path);
        }

        T ret = t.gameObject.GetComponent<T>();
        if (ret == null)
        {
            ret = t.gameObject.AddComponent<T>();
        }
        return ret;
    }

    public static T GetOrAddCompoment<T>(this Transform trans, string path = "") where T : Component
    {
        return trans.gameObject.GetOrAddCompoment<T>(path);
    }

    public static T GetOrAddCompoment<T>(this MonoBehaviour momo, string path = "") where T : Component
    {
        return momo.gameObject.GetOrAddCompoment<T>(path);
    }

    public static T GetComponent<T>(this Transform go, string path) where T : Component
    {
        Transform temp = go;
        if (string.IsNullOrEmpty(path) == false)
        {
            temp = go.Find(path);
            if (temp == null)
            {
                return null;
            }
        }
        return temp.GetComponent<T>();
    }

    public static EventListener SetEventListener(this Transform go, E_TouchType touchType, OnTouchHandle handler, params object[] args)
    {
        return go.SetEventListener("", touchType, handler, args);
    }

    public static EventListener SetEventListener(this Transform go, string path, E_TouchType touchType, OnTouchHandle handler, params object[] args)
    {
        if (string.IsNullOrEmpty(path) == false)
        {
            go = go.Find(path);
        }
        EventListener listener = EventListener.Get(go);
        listener.SetEventListener(touchType, handler, args);
        return listener;
    }
}

