﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryInUI : MonoBehaviour
{
    public int count = 0;
    void Start()
    {
        if (count == 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    void Update()
    {

    }
}
