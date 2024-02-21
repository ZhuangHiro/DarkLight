using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	// Use this for initialization
	void OnMouseEnter () {
        CursorManager._instance.SetNpcTalk();
	}
	
	// Update is called once per frame
	void OnMouseExit () {
        CursorManager._instance.SetNormal();
    }
}
