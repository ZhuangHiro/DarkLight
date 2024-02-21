using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rank : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int count = transform.parent.childCount - 1;//Panel移位
        transform.SetSiblingIndex(count);
    }
}
