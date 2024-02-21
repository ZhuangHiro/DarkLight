using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour {

    private bool anyKeyDown = false;
    private GameObject gameButton;

	// Use this for initialization
	void Start () {
        gameButton = this.transform.parent.Find("buttonContainer").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(anyKeyDown == false)
        {
            if (Input.anyKey)
            {
                ShowButton();
            }
        }
	}
    void ShowButton()
    {
        gameButton.SetActive(true);
        this.gameObject.SetActive(false);
        anyKeyDown = true;
    }
}
