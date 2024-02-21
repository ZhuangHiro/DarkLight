using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour
{

    public String SceneName = "";
    void Awake()
    {
        EventListener.Get(transform).SetEventListener(E_TouchType.OnClick, OnClick, null);
    }

    public virtual void OnClick(GameObject target, object eventData, object[] _params)
    {
        if (SceneName != "")
        {
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(delegate
            {
                SceneManager.LoadScene(SceneName);
            }, 0.5f));

        }
    }
}
