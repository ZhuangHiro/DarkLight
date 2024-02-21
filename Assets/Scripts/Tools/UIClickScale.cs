using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickScale : MonoBehaviour {

	void Start () {
		EventListener.Get(transform).SetEventListener(E_TouchType.OnClick,OnClick,null);
	    EventListener.Get(transform).SetEventListener(E_TouchType.OnExit, OnDropClick, null);

    }

    private void OnDropClick(GameObject target, object eventdata, object[] _params)
    {
        transform.localScale = Vector3.one;
    }

    private void OnClick(GameObject target, object eventData, object[] _params)
    {
        transform.localScale = 1.2f * Vector3.one;
    } 


}
