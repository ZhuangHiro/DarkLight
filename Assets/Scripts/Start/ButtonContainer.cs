using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContainer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnNewGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 0);//DataFromSave表示数据来自保存
    }
    public void OnLoadGame()
    {
        PlayerPrefs.SetInt("DataFromSave", 1);//DataFromSave表示数据来自保存
    }
}
