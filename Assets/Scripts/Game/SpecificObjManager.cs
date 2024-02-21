using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificObjManager : MonoBehaviour {

    private static SpecificObjManager _instance = null;

    public static SpecificObjManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SpecificObjManager is null");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
