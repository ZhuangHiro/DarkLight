using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodUI : MonoBehaviour
{
    public int count = 0;

    private static WoodUI _instance;

    public static WoodUI Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("WoodUI Instance is null...");
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        if (count == 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
