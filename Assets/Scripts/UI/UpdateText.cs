using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {
    public Text tooltip;
    public Text content;
    
    // Use this for initialization

    void Awake()
    {
       
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tooltip.text = content.text;
        Vector2 position = Input.mousePosition;
        transform.localPosition = position;
    }
    
}
