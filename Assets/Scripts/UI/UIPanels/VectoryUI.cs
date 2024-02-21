using System.Collections;
using System.Collections.Generic;
using MadLevelManager;
using UnityEngine;

public class VectoryUI : MonoBehaviour
{
	private static VectoryUI _instance = null;
	public static VectoryUI Instance
	{
		get
		{

			if (_instance == null)
			{
				Debug.LogError("VectoryUI Instance is null...");
			}
			
			return _instance;
			
		}
	}

    private Transform next_button;

	void Awake()
	{
		_instance = this;
	    next_button = transform.GetComponent<Transform>("next_button");
	}

	void Start () {
		EventListener.Get(next_button).SetEventListener(E_TouchType.OnClick,OnNextClick,null);
	}

    private void OnNextClick(GameObject target, object eventdata, object[] _params)
    {
        MadLevel.LoadNext();
    }
    
	void Update () {
		
	}
}
